Agile CRM C# API
================
Agile CRM is a new breed CRM. You can sign up @ [AgileCRM.com](https://www.agilecrm.com).  

Requirements
------------

1. C# 3.0 with .NET 3.5 or later.

2. Any JSON library. There's many available over the internet. One of them is [Json.NET] (http://james.newtonking.com/pages/json-net.aspx).

3. Setting Domain Name and Api Key

![Finding Domain name and api key] (https://github.com/agilecrm/c-sharp-api/blob/master/Agile_CRM_API_Key_New.jpg)

In the above image, api key is present at the "Api & Analytics" tab at `https://mycompany.agilecrm.com/#account-prefs`.

        Domain Name : mycompany
        Api Key     : myagilecrmapikey

So you have to update your

            using System;   
            using System.Net;   
            using System.Web;   
            using System.IO;   
            using System.Security.Cryptography.X509Certificates;   
   
            public class Agile: ICertificatePolicy    
            {   
              /*******Please insert your Domain Name and Api Key here*********/   
              const string domain = "mycompany";   
              const string apiKey = "myagilecrmapikey";   
              /***************************************************************/    
              .   
              .   



API's Details
-------------
###1. Contact 
#####1.1 `string Agile.GetContact(string email)`  
This is used to retrieve the contact details of a person. It will return in json format.

#####1.2 `string Agile.CreateContact(string contactJson)`  
This is used to create a new contact with properties mentioned in `contactJson`.

#####1.3 `string Agile.UpdateContact(string email,string contactJson)`
This is used to update a contact with `contactJson`. Please check example for data formate of contactJson.

#####1.4 `string Agile.DeleteContact(string email)`  
This is used to delete contact details of the person.

###2. Property
#####2.1 `string Agile.AddProperty(string email, string property)`  
This is used to add/modify the property of a contact. Here `property` is a json object containing property data and value to be added.

###3. Score
#####3.1 `string Agile.GetScore(string email)`  
This is to retrieve the score of a contact.

#####3.2 `string Agile.AddScore( string email, int score)`  
This is to increment score of a contact by `score` units.

#####3.3 `string Agile.SubtractScore( string email, int score)`  
This is to decrement score of a contact by `score` units.

###4. Notes
#####4.1 `string Agile.GetNotes(string email)`   
This is to retrieve notes of a contact.

#####4.2 `string Agile.AddNote(string email, string note)`   
This is used to add a note represented with a stringified json object to a contact. Here `note` is a json object containing the subject and description field of the note.

###5. Tags
#####5.1 `string Agile.GetTags(string email)`   
This is to retrieve tags of a contact.

#####5.2 `string Agile.AddTags(string email, string tags)`   
This is to add tags to a contact. Here,   

    string tags = "tag1, tag2, tag3";
         (or) 
    string tags = "tag1 tag2 tag3";

#####5.3 `string Agile.RemoveTags(string email, string tags)`   
This is to remove tags referred by `tags` from a contact. Here,   

    string tags = "tag1, tag2, tag3"; 
        (or)
    string tags = "tag1 tag2 tag3";

###6. Tasks
#####6.1 `string Agile.GetTasks(string email)`   
This is to retrieve tasks of a contact.

#####6.2 `string Agile.CreateTask(string email, string taskJson)`   
This is used to add a task with property mentioned in `taskJson` to a contact. Here task is passed in a stringified json format.

###7. Deals
#####7.1 `string Agile.GetDeals(string email)`   
This is to retrieve all the deals of a contact.

#####7.2 `string Agile.CreateDeals(string email, string deal)`   
This is used to add detail about a deal referred by `deal` to a contact. Here 'opportunity' is a strinfied json object, where original json object is in a form of :  
    
    {   
    "name": "Deal sales", "description": "brief description on deal",   
    "expected_value": "100", "milestone":"won",    
    "close_date": data as epoch time   
    }

###8. Campaigns
#####8.1 `string Agile.GetCampaigns(string email)`   
This is to retrieve details of all campaigns associated with a contact.

#####8.2 `string Agile.AddCampaign(string email, string campaign)`   
This is used to add campaign based on contact email to already existing workflow. 

#####8.3 `string Agile.GetCampaignLogs(string email)`   
This is to retrieve logs of all campaings associated with a contact.

###9. Contact & Workflow
#####9.1 `string Agile.SubscribeContact(long contactId, long workflowId)`   
Enrolls a contact with `contactId` to a particular workflow with `workflowId`.

###10. Workflows
#####10.1 `string Agile.GetWorkflows()`   
This is to retrieve the workflow of the user.

###11. Gadget Templates
#####11.1 `string Agile.GetGadgetTemplate(string gadget)`   
This is used to return the template of the gadget with name `gadget`.

Examples
--------

    //Fetching Contact detail from email in stringified json format.
    string result = Agile.GetContact("jobs@apple.com");
    
    
    //Deleting a contact by email.
    string email = "dupemail@outlook.com";
    result = Agile.DeleteContact(email);


    //Saving a contact.
    string contactDetail = "{\"lead_score\":44,  \"tags\":[\"tag1\", \"tag2\"], \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"email\",\"value\":\"contact@mail.org\"}, {\"type\":\"SYSTEM\", \"name\":\"first_name\", \"value\":\"First_name\"}, {\"type\":\"SYSTEM\", \"name\":\"last_name\", \"value\":\"Last_name\"}]}";
    result = Agile.CreateContact(contactDetail);
                    OR
    string contactDetail = @"{""lead_score"":44, ""tags"":[""tag1"", ""tag2""], ""properties"":[{""type"":""SYSTEM"", ""name"":""email"",""value"":""contact@mail.org""}, {""type"":""SYSTEM"", ""name"":""first_name"", ""value"":""First_name""}, {""type"":""SYSTEM"", ""name"":""last_name"", ""value"":""Last_name""}]}";
    result = Agile.CreateContact(contactDetail);
    
    
    //Update a contact by email.
    string contactDetail = @"{""email"":""pintu@hotmail.com"", ""first_name"":""April"", ""last_name"":""Woodlif"",""TeamNumbers"":""5"", ""text sample test"":""text custom"", ""DOP"":""1449599400""}";
    result = Agile.UpdateContact("pintu@hotmail.com",contactDetail);
    
    
    //Adding Score
    result = Agile.AddScore("jobs@apple.com", 12);


    //Subtracting Score
    result = Agile.SubtractScore ("jobs@apple.com", 12);


    //Adding tag.
    result = Agile.AddTags("jobs@apple.com", "hihoho");


    //Removing tag.
    result = Agile.RemoveTags("jobs@apple.com", "hohoho");


    //Subscribe client with id 2001 to campaign #10001.
    result = Agile.SubscribeContact(2001,10001);


    //Get score of contact associated with 'email'.
    result = Agile.GetScore("jobs@apple.com");


    //Get all notes associated with 'email'.
    result = Agile.GetNotes("jobs@apple.com");


    //Get all tags associated with 'email'.
    result = Agile.GetTags("jobs@apple.com");


    //Get all tasks associated with 'email'.
    result = Agile.GetTasks("jobs@apple.com");


    // Creating Tasks
    string taskJson = "{\"type\":\"CALL\", \"priority_type\":\"HIGH\", \"subject\":\"call him\"}";
    result = Agile.CreateTask("jobs@apple.com",taskJson);
                OR
    string taskJson = @"{""type"":""CALL"", ""priority_type"":""HIGH"", ""subject"":""call him""}";
    result = Agile.CreateTask("jobs@apple.com",taskJson);


    //Get all campaigns associated with 'email'.
    result = Agile.GetCampaigns("jobs@apple.com");


    //Get all log of campaigns associated with 'email'.
    result = Agile.GetCampaignsLogs("jobs@apple.com");


    //Get all workflow of the domain.
    result = Agile.GetWorkflows();

