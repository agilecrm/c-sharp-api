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
namespace AgileCRMAPI
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
		const string domain = "your_domain";
		const string email = "your_agilecrm_email";
		const string apiKey = "your_rest_api_key";
		/***************************************************************/

		const string domainUrl = "https://" + domain + ".agilecrm.com/dev/api/";
		
		private static string agileCRM(string nextUrl, string method, string data, string contenttype)
		{
			try {
				string url = domainUrl + nextUrl; 

				//Console.WriteLine(url);
				String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(email + ":" + apiKey));

				HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
				
				if (!string.IsNullOrEmpty(data))
					request.ContentLength = data.Length;
				
				request.Method = method;
				request.ContentType = contenttype;
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
			 Get Contact by Email
			 string s1 = agileCRM("contacts/search/email/samson@walt.ltd", "GET", null,"application/json");
			
			 Console.WriteLine(s1);
				
			// Create a Contact
			
			string contactDetail = "{\"lead_score\":44,  \"tags\":[\"tag1\", \"tag2\"], \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"email\",\"value\":\"jason123@gmail.com\"}, {\"type\":\"SYSTEM\", \"name\":\"first_name\", \"value\":\"First_name\"}, {\"type\":\"SYSTEM\", \"name\":\"last_name\", \"value\":\"Last_name\"}]}";
			
			string s2 = agileCRM("contacts", "POST", contactDetail,"application/json");
			
			Console.WriteLine(s2);
			
			// Delete a contact
			agileCRM("contacts/5765003219042304", "DELETE", null,"application/json");
	 		
			// Update Contacts
	 		
			string updatecontactDetail = "{\"id\":5749641194766336, \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"email\",\"value\":\"pbx.kumar@gmail.com\"}, {\"type\":\"SYSTEM\", \"name\":\"first_name\", \"value\":\"PBX\"}, {\"type\":\"SYSTEM\", \"name\":\"last_name\", \"value\":\"Los\"}]}";

			string s3 = agileCRM("contacts/edit-properties", "PUT", updatecontactDetail,"application/json");

			Console.WriteLine(s3);
			
			// Update score
			string updatecontactScore = "{\"id\":5749641194766336, \"lead_score\":150}";

			string s4 = agileCRM("contacts/edit/lead-score", "PUT", updatecontactScore,"application/json");

			Console.WriteLine(s4);
			
			// Update star
			string updatecontactStar = "{\"id\":5749641194766336, \"star_value\":5}";

			string s5 = agileCRM("contacts/edit/add-star", "PUT", updatecontactStar,"application/json");

			Console.WriteLine(s5);
			
			// Update tags
			string updatecontactTags = "{\"id\":5749641194766336, \"tags\":[\"tag1\", \"tag2\"]}";

			string s6 = agileCRM("contacts/edit/tags", "PUT", updatecontactTags,"application/json");

			Console.WriteLine(s6);
			
			// Delete tags
			string deletecontactTags = "{\"id\":5749641194766336, \"tags\":[\"tag1\", \"tag2\"]}";

			string s7 = agileCRM("contacts/delete/tags", "PUT", deletecontactTags,"application/json");

			Console.WriteLine(s7);
			
			Console.WriteLine("Done");
		}
	}
	
}
