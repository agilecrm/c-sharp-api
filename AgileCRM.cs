/*
 * Created by SharpDevelop.
 * User: graut
 * Date: 04-03-2016
 * Time: 15:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Web;
using System.IO;
using System.Security.Cryptography.X509Certificates;
namespace HelloWorld1
{
	/// <summary>
	/// Description of AgileCRM.
	/// </summary>
	public class AgileCRM
	{
		public AgileCRM()
		{
		}
		
		/*******Please insert your Domain Name and email Api Key here*********/
		const string domain = "jason";
		const string email = "jason@agilecrm.com";
		const string apiKey = "******************";
		/***************************************************************/

		const string domainUrl = "https://" + domain + ".agilecrm.com/dev/api/";
		
		private static string agileCRM(string nextUrl, string method, string data)
		{
			try {
				string url = domainUrl + nextUrl; 

				//Console.WriteLine(url);
				String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(email + ":" + apiKey));

				HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
				
				if (!string.IsNullOrEmpty(data))
					request.ContentLength = data.Length;
				
				request.Method = method;
				request.ContentType = "application/json";
				request.Accept = "application/json";
				
				request.Headers.Add("Authorization", "Basic " + encoded);
				string result = null;
				
				switch (method) {
					case "GET":
						using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
							Stream dataStream = response.GetResponseStream();
							StreamReader reader = new StreamReader(dataStream);
							result = reader.ReadToEnd();

							reader.Close();
							dataStream.Close();
							response.Close();
						}

						return result;
						break;
					case "POST":
						using (Stream webStream = request.GetRequestStream())
						using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII)) {
							requestWriter.Write(data);
						}
						using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
							Stream dataStream = response.GetResponseStream();
							StreamReader reader = new StreamReader(dataStream);
							result = reader.ReadToEnd();

							reader.Close();
							dataStream.Close();
							response.Close();
						}

						return result;
						break;
					case "PUT":
						using (Stream webStream = request.GetRequestStream())
						using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII)) {
							requestWriter.Write(data);
						}
						using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
							Stream dataStream = response.GetResponseStream();
							StreamReader reader = new StreamReader(dataStream);
							result = reader.ReadToEnd();

							reader.Close();
							dataStream.Close();
							response.Close();
						}

						return result;
						break;
					case "DELETE":
						using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
							Stream dataStream = response.GetResponseStream();
							StreamReader reader = new StreamReader(dataStream);
							result = reader.ReadToEnd();

							reader.Close();
							dataStream.Close();
							response.Close();
						}

						return result;
						break;						
					default:
						return "nothing";
						break;
				}
				
				
				
			} catch (Exception e) {
				return "Exception caught!!!\n" + e.ToString();
			}
		}
		static void Main(string[] args)
		{
			// Get Contact by Email
			string s = agileCRM("contacts/search/email/samson@walt.ltd", "GET", null);
			
			Console.WriteLine(s);
				
			// Create a Contact
			
			string contactDetail = "{\"lead_score\":44,  \"tags\":[\"tag1\", \"tag2\"], \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"email\",\"value\":\"jason123@gmail.com\"}, {\"type\":\"SYSTEM\", \"name\":\"first_name\", \"value\":\"First_name\"}, {\"type\":\"SYSTEM\", \"name\":\"last_name\", \"value\":\"Last_name\"}]}";
			
			string s1 = agileCRM("contacts", "POST", contactDetail);
			
			Console.WriteLine(s1);
			
			// Delete a contact
	 		agileCRM("contacts/5765003219042304", "DELETE", null);
			
	
			Console.WriteLine("Done");
		}
	}
	
}
