Agile CRM C# API 
=================

[Agile CRM] (https://www.agilecrm.com/) is a new breed CRM software with sales and marketing automation.

Table of contents
---------------

**[Requirements](#requirements)**

**[1 Contact](#1-contact)**
  * [1.1 To create a contact](#11-to-create-a-contact)
  * [1.2 To fetch contact data](#12-to-fetch-contact-data)
  * [1.3 To delete a contact](#13-to-delete-a-contact)
  * [1.4 To update a contact](#14-to-update-a-contact)
  

**[2. Company](#2-company)**
  * [2.1 To create a company](#21-to-create-a-company)
  * [2.2 To get a company](#22-to-get-a-company)
  * [2.3 To delete a company](#23-to-delete-a-company)
  * [2.4 To update a company](#24-to-update-a-company)
  * [2.5 Update properties of a company (partial update)](#25-update-properties-of-a-company-partial-update)best to use against update company :+1:
  * [2.6 Update star value of a company](#26-update-star-value-of-a-company)
  * [2.7 Get list of companies](#27-get-list-of-companies)
  * [2.8 Search Contacts/Companies](#28-search-contactscompanies)

**[3. Deal (Opportunity)](#3-deal-opportunity)**
  * [3.1 To create a deal](#31-to-create-a-deal)
  * [3.2 To get a deal](#32-to-get-a-deal)
  * [3.3 To delete a deal](#33-to-delete-a-deal)
  * [3.4 To update deal](#34-to-update-deal)
  * [3.5 To update deal (Partial update)](#35-to-update-deal-partial-update)best to use against update deal :+1:
  * [3.6 Get deals related to specific contact by contact id](#36-get-deals-related-to-specific-contact-by-contact-id)

**[4. Note](#4-note)**
  * [4.1 To create a note](#41-to-create-a-note)
  * [4.2 To get all notes related to specific contact](#42-to-get-all-notes-related-to-specific-contact)
  * [4.3 To update a note](#43-to-update-a-note)
  
**[5. Task](#5-task)**
  * [5.1 To create a task](#51-to-create-a-task)
  * [5.2 To get a task](#52-to-get-a-task)
  * [5.3 To delete a task](#53-to-delete-a-task)
  * [5.4 To update a task](#54-to-update-a-task)

**[6. Event](#6-event)**
  * [6.1 To create a event](#61-to-create-a-event)
  * [6.2 To delete a event](#62-to-delete-a-event)
  * [6.3 To update a event](#63-to-update-a-event)

**[7. Deal Tracks and Milestones](#7-deal-tracks-and-milestones)**
  * [7.1 To create a track](#71-to-create-a-track)
  * [7.2 To get all tracks](#72-to-get-all-tracks)
  * [7.3 To update track](#73-to-update-track)
  * [7.4 To delete a track](#74-to-delete-a-track)  

Requirements
------------

1. C# 3.0 with .NET 3.5 or later.

2. Any JSON library. There's many available over the internet. One of them is [Json.NET] (http://james.newtonking.com/pages/json-net.aspx).

3. Setting Domain Name and Api Key

![Finding Domain name and api key] (https://github.com/agilecrm/c-sharp-api/blob/master/Agile_CRM_API_Key_New.jpg)

In the above image, api key is present at the "Api & Analytics" tab at `https://mycompany.agilecrm.com/#account-prefs`.

        Domain Name : mycompany
        Api Key     : myagilecrmapikey
        Email       : myagilecrmemail

So you have to update your `https://github.com/agilecrm/c-sharp-api/blob/master/AgileCRM.cs`

       using System;
       using System.Net;
       using System.Web;
       using System.IO;
       using System.Security.Cryptography.X509Certificates;
       namespace AgileAPI
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



API's Details
-------------
## 1. Contact
#### 1.1 To create a contact 

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation)

```javascript
string contactDetail = "{\"lead_score\":44,  \"tags\":[\"tag1\", \"tag2\"], \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"email\",\"value\":\"jason123@gmail.com\"}, {\"type\":\"SYSTEM\", \"name\":\"first_name\", \"value\":\"First_name\"}, {\"type\":\"SYSTEM\", \"name\":\"last_name\", \"value\":\"Last_name\"}]}";
	
string s1 = agileCRM("contacts", "POST", contactDetail,"application/json");
	
Console.WriteLine(s1);
```

#### 1.2 To fetch contact data

###### by id

```javascript
// Get contact by ID
string result = agileCRM("contacts/5765003219042304", "GET", null,"application/json");
```
###### by email

```javascript
// Get contact by Email
string result = agileCRM("contacts/search/email/samson@walt.ltd", "GET", null,"application/json");
```

#### 1.3 To delete a contact

```javascript
// Delete a contact
agileCRM("contacts/5765003219042304", "DELETE", null,"application/json");
```

#### 1.4 To update a contact 

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation-1)

```javascript
string updatecontactDetail = "{\"id\":5765003219042304, \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"email\",\"value\":\"jason123@gmail.com\"}, {\"type\":\"SYSTEM\", \"name\":\"first_name\", \"value\":\"First_name\"}, {\"type\":\"SYSTEM\", \"name\":\"last_name\", \"value\":\"Last_name\"}]}";
			
string result = agileCRM("contacts/edit-properties", "PUT", updatecontactDetail,"application/json");
			
Console.WriteLine(result);
```

#### 1.5 Update lead score by ID

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#15-update-lead-score-by-id)

```javascript
string updatecontactScore = "{\"id\":5749641194766336, \"lead_score\":150}";

string result = agileCRM("contacts/edit/lead-score", "PUT", updatecontactScore,"application/json");

Console.WriteLine(result);
```

#### 1.6 Update star value by ID

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#16-update-star-value-by-id)

```javascript
string updatecontactStar = "{\"id\":5749641194766336, \"star_value\":5}";

string result = agileCRM("contacts/edit/add-star", "PUT", updatecontactStar,"application/json");

Console.WriteLine(result);
```

#### 1.7 Update tags value by ID

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation-4)

```javascript
string updatecontactTags = "{\"id\":5749641194766336, \"tags\":[\"tag1\", \"tag2\"]}";

string result = agileCRM("contacts/edit/tags", "PUT", updatecontactTags,"application/json");

Console.WriteLine(result);
```

#### 1.8 Delete tags value by ID

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation-5)

```javascript
string updatecontactTags = "{\"id\":5749641194766336, \"tags\":[\"tag1\", \"tag2\"]}";

string result = agileCRM("contacts/delete/tags", "PUT", deletecontactTags,"application/json");

Console.WriteLine(result);
```

#### 1.9 Search contacts/companies

```javascript
string result = agileCRM("search?q=ghanshyam raut&page_size=10&type='PERSON'", "GET", null,"application/json");

Console.WriteLine(result);
```

#### 1.10 Adding tags to a contact based on email

```javascript
string postda ="email=pbx.kumar@gmail.com&tags=['testingtesto']";

string result = agileCRM("contacts/email/tags/add", "POST", postda,"application/x-www-form-urlencoded");

Console.WriteLine(result);
```

#### 1.11 Delete tags to a contact based on email

```javascript
string postda ="email=pbx.kumar@gmail.com&tags=['testingtesto']";

string result = agileCRM("contacts/email/tags/delete", "POST", postda,"application/x-www-form-urlencoded");

Console.WriteLine(result);
```

#### 1.12 Add score to a contact using email ID

```javascript
string postda ="email=pbx.kumar@gmail.com&score=100";

string result = agileCRM("contacts/add-score", "POST", postda,"application/x-www-form-urlencoded");

Console.WriteLine(result);
```

## 2. Company
#### 2.1 To create a company 

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation-7)

```javascript
string companyDetail = "{\"type\":\"COMPANY\",\"lead_score\":44,  \"tags\":[\"tag1\", \"tag2\"], \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"name\",\"value\":\"Oracle\"}, {\"type\":\"SYSTEM\", \"name\":\"url\", \"value\":\"oracle.com\"}, {\"type\":\"CUSTOM\", \"name\":\"Company Type\", \"value\":\"MNC\"}]}";
	
string s1 = agileCRM("contacts", "POST", companyDetail,"application/json");
	
Console.WriteLine(s1);
```

#### 2.2 To update a company 

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation-8)

```javascript
string updatecompanyDetail = "{\"id\":5661679325020160, \"properties\":[{\"type\":\"SYSTEM\", \"name\":\"name\",\"value\":\"Oracl\"}, {\"type\":\"SYSTEM\", \"name\":\"url\", \"value\":\"oracle.com\"}, {\"type\":\"CUSTOM\", \"name\":\"Company Type\", \"value\":\"MNCT\"}]}";
	
string s1 = agileCRM("contacts/edit-properties", "PUT", updatecompanyDetail,"application/json");

Console.WriteLine(s1);
```

## 3. Deal
#### 3.1 To create a deal 

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation-9)

```javascript
string dealDetail = "{\"name\":\"Deal-Tomato11111\",\"expected_value\":\"500\",\"probability\":90,\"close_date\":1455042600,\"milestone\":\"Proposal\",  \"contact_ids\":[\"5749641194766336\", \"5758948741218306\"], \"custom_data\":[{\"name\":\"Group Size\",\"value\":\"20\"}]}";
	
string s1 = agileCRM("opportunity", "POST", dealDetail,"application/json");
	
Console.WriteLine(s1);
```

#### 3.2 To update a deal 

- [**Acceptable request representation for contact**](https://github.com/agilecrm/rest-api#acceptable-request-representation-10)

```javascript
string updatedealDetail = "{\"id\":5722251114577920,\"name\":\"Deal-Tomato Updated\",\"expected_value\":\"900\",\"probability\":90,\"close_date\":1455042600,\"milestone\":\"Proposal\",  \"contact_ids\":[\"5749641194766336\", \"5758948741218306\"], \"custom_data\":[{\"name\":\"Group Size\",\"value\":\"20\"}]}";
	
string s1 = agileCRM("opportunity/partial-update", "PUT", updatedealDetail,"application/json");
	
Console.WriteLine(s1);
```

#### 3.3 Create deal to a contact using email ID 

```javascript
string dealDetail = "{\"name\":\"Deal-Tomato11111\",\"expected_value\":\"500\",\"probability\":90,\"close_date\":1455042600,\"milestone\":\"Proposal\",  \"contact_ids\":[\"5749641194766336\", \"5758948741218306\"], \"custom_data\":[{\"name\":\"Group Size\",\"value\":\"20\"}]}";
	
string s1 = agileCRM("opportunity/email/pbx.kumar@gmail.com", "POST", dealDetail,"application/json");
	
Console.WriteLine(s1);
```

#### 3.4 Get list of deal

- [**Reference**](https://github.com/agilecrm/rest-api#31-listing-deals)

```javascript
string s1 = agileCRM("opportunity?page_size=10&cursor=Cj8SOWoRc35hZ2lsZS1jcm0tY2xvdWRyGAsSC09wcG9ydHVuaXR5GICAgMCV5oEJDKIBCWdoYW5zaHlhbRgAIAA", "GET", null,"application/json");
	
Console.WriteLine(s1);
```

#### 3.5 Get deal by ID


```javascript
string s1 = agileCRM("opportunity/5733975435771904", "GET", null,"application/json");
	
Console.WriteLine(s1);
```

#### 3.6 Delete deal by ID


```javascript
string s1 = agileCRM("opportunity/5733975435771904", "DELETE", null,"application/json");
	
Console.WriteLine(s1);
```
