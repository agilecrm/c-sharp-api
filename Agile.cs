using System;
using System.Net;
using System.Web;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class Agile: ICertificatePolicy 
{
  /*******Please insert your Domain Name and Api Key here*********/
  const string domain = "xxx";
  const string apiKey = "xxx";
  /***************************************************************/ 

  const string  domainUrl = "https://" + domain + ".agilecrm.com/core/js/api/";

  /*
   * If no such contact found, returns a json string where value of 'id' key maps to 'null'.
   */
  static public string GetContact(string email) 
  {
    string nextUrl = "contact/email/";
    string queryString = "email=" +email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  } 

  /*
   * It creates a contact with description 'contactJson'.
   */
  static public string CreateContact(string contactJson) 
  {
    string nextUrl = "contacts/";
    string queryString = "contact=" + contactJson;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns null if no contact is found otherwise a success status.
   */
  static public string DeleteContact(string email) 
  {
    string nextUrl = "contact/delete/";
    string queryString = "email=" +email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Create a task represented by 'taskJson', in stringified json format, for contact associated with 'email'.
   */
  static public string CreateTask(string email, string taskJson) 
  {
    string nextUrl = "task/";
    string queryString = "email=" + email + "&task=" + taskJson;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Add deal and relate contact to the deal 'opportunity', in stringified json format.
   */
  static public string CreateDeals(string email, string deal) 
  {
    string nextUrl = "opportunity/";
    string queryString = "email=" + email + "&opportunity=" + deal;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Add/replace 'property', in stringified json format, with the contact associated with 'email'.
   */
  static public string AddProperty(string email, string property) 
  {
    string nextUrl = "contacts/add-property/";
    string queryString = "email=" + email + "&data=" + property;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Add 'note', in stringified json format, to the contact associated with 'email'
   */
  static public string AddNote(string email, string note) 
  {
    string nextUrl = "contacts/add-note/";
    string queryString = "email=" + email + "&data=" + note;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Add 'campaign', in stringified json format, to the contact associated 'email'.
   */
  static public string AddCampaign(string email, string campaign) 
  {
    string nextUrl = "contacts/add-campaign/";
    string queryString = "email=" + email + "&data=" + campaign;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Get template of gadget 'gadget'.
   */
  static public string GetGadgetTemplate(string gadget) 
  {
    string nextUrl = "gmail-template/";
    string queryString = "template=" + gadget;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Add 'score' to the score of contact associated with 'email' email. It always returns null.
   */
  static public string AddScore( string email, int score) 
  {
    string nextUrl = "contacts/add-score/";
    string queryString = "email=" +email + "&score=" + score;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Subtract 'score' from the score of contact associated with 'email' email. It always returns null.
   */
  static public string SubtractScore( string email, int score) 
  {
    string nextUrl = "contacts/subtract-score/";
    string queryString = "email=" +email + "&score=" + score;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Add tags mentioned in 'tags' to the contact with email 'email'. If tag is already present it returns the contact in stringified json object.
   */
  static public string AddTags(string email, string tags) 
  {
    string nextUrl = "contacts/add-tags/";
    string queryString = "email=" + email + "&tags=" +tags;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Remove tags mentioned in 'tags' to the contact with email 'email'. If tag is already absent, it returns contact in stringified json object.
   */
  static public string RemoveTags(string email, string tags) 
  {
    string nextUrl = "contacts/remove-tags/";
    string queryString = "email=" + email + "&tags=" +tags;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Enrolls a contact with contact id "contactId" to workflow with id "workflowId"
   */
  // ** It will return some EXCEPTION, IGNORE this.
  static public string SubscribeContact(long contactId, long workflowId) 
  {
    string nextUrl = "campaign/enroll/" + contactId + "/" + workflowId+"/";
    string queryString = "";

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns the score of contact with email 'email'. If there's no such contact returns a null object.
   */
  static public string GetScore(string email) 
  {
    string nextUrl = "contacts/get-score/";
    string queryString = "email=" + email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns the notes in sringified json object form of contact with email 'email'. If there's no such contact returns a null object.
   */
  static public string GetNotes(string email) 
  {
    string nextUrl = "contacts/get-notes/";
    string queryString = "email=" + email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns the tags of contact with email 'email'. If there's no such contact returns a null object. Result will be stringified form of array of strings, eg., "[\"tag1\", \"tag2\"]"
   */
  static public string GetTags(string email) 
  {
    string nextUrl = "contacts/get-tags/";
    string queryString = "email=" + email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns the tasks of contact with email 'email'. If there's no such contact returns a null object.
   */
  static public string GetTasks(string email) 
  {
    string nextUrl = "contacts/get-tasks/";
    string queryString = "email=" + email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns the deals with contact with email 'email'. If there's no such contact returns a null object.
   */
  static public string GetDeals(string email) 
  {
    string nextUrl = "contacts/get-deals/";
    string queryString = "email=" + email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns all the detail of the campaings with which contact with 'emai' is associated.
   */
  static public string GetCampaigns(string email) 
  {
    string nextUrl = "contacts/get-campaigns/";
    string queryString = "email=" + email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns all log of the campaings with which contact with 'emai' is associated.
   */
  static public string GetCampaignLogs(string email) 
  {
    string nextUrl = "contacts/get-campaign-logs/";
    string queryString = "email=" + email;

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /*
   * Returns all the work flow of current domain user. Result will be stringified form of array of strings.
   */
  static public string GetWorkflows() 
  {
    string nextUrl = "contacts/get-workflows/";
    string queryString = "";

    string result = HttpGet(nextUrl, queryString);
    return result;
  }

  /************************PRIVATE****************************************/

  private static string HttpGet(string nextUrl, string queryString) 
  {
    try 
    {
      string url = domainUrl + nextUrl + "?" + "id=" + apiKey; 

      if(!string.IsNullOrEmpty(queryString))
        url += "&" + queryString;

      // url = System.Web.HttpUtility.UrlEncode(url);   // Library not provided everywhere, at least at mono.
      //url = System.Uri.EscapeUriString(url);          // Should not be used for encoding whole url.
      url = System.Uri.EscapeDataString(url);
      //url = System.Net.WebUtility.UrlEncode(url);

      //Console.WriteLine(url);

      HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
      request.Method = "GET";
      string result = null;

      using(HttpWebResponse response = request.GetResponse() as HttpWebResponse) 
      {
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        result = reader.ReadToEnd();

        reader.Close();
        dataStream.Close();
        response.Close();
      }

      return result;
    }
    catch (Exception e)
    {
      return "Exception caught!!!\n" + e.ToString();
    }
  }

  public bool CheckValidationResult(ServicePoint sp, X509Certificate certificate, WebRequest request, int error) 
  {
    return true;
  }
}

