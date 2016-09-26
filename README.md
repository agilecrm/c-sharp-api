Agile CRM C# API 
=================

[Agile CRM] (https://www.agilecrm.com/) is a new breed CRM software with sales and marketing automation.

Table of contents
---------------

**[Requirements](#requirements)**

**[1 Contact](#1-contact)**
  * [1 To create a contact](#11-to-create-a-contact)
  * [2 To fetch contact data](#12-to-fetch-contact-data)
  * [3 To delete a contact](#13-to-delete-a-contact)
  * [4 To update a contact](#14-to-update-a-contact)
  * [5 Update lead score by ID](#15-update-lead-score-by-id)
  * [6 Update star value by ID](#16-update-star-value-by-id)
  * [7 Update tags value by ID](#17-update-tags-value-by-id)
  * [8 Delete tags value by ID](#18-delete-tags-value-by-id)
  * [9 Search contacts/companies](#19-search-contactscompanies)
  * [10 Adding tags to a contact based on email](#110-adding-tags-to-a-contact-based-on-email)
  * [11 Delete tags to a contact based on email](#111-delete-tags-to-a-contact-based-on-email)
  * [12 Add score to a contact using email ID](#112-add-score-to-a-contact-using-email-id)
  

**[2. Company](#2-company)**
  * [1 To create a company](#21-to-create-a-company)
  * [2 To update a company](#22-to-update-a-company)
 
**[3. Deal (Opportunity)](#3-deal)**
  * [1 To create a deal](#31-to-create-a-deal)
  * [2 To update a deal](#32-to-update-a-deal)
  * [3 Create deal to a contact using email ID](#33-create-deal-to-a-contact-using-email-id)
  * [4 Get list of deal](#34-get-list-of-deal)
  * [5 Get deal by ID](#35-get-deal-by-id)
  * [6 Delete deal by ID](#36-delete-deal-by-id)

**[4. Note ](#4-note)**
  * [1 Create a note and relate that to contacts](#41-create-a-note-and-relate-that-to-contacts)
  * [2 Add note to a contact using email ID](#42-add-note-to-a-contact-using-email-id)
  * [3 Gets notes related to specific contact](#43-gets-notes-related-to-specific-contact)
  * [4 Delete a specific note from specific contact](#44-delete-a-specific-note-from-specific-contact)
  * [5 Create note to a deal](#45-create-note-to-a-deal)
  * [6 Update note to a deal](#46-update-note-to-a-deal)
  * [7 Gets notes related to specific deal](#47-gets-notes-related-to-specific-deal)
  
**[5. Task ](#4-task)**
  * [1 Create a task and relate that to contacts](#51-create-a-task-and-relate-that-to-contacts)
  * [2 Add task to a contact using email ID](#52-add-task-to-a-contact-using-email-id)
  * [3 Gets tasks related to specific contact](#53-gets-tasks-related-to-specific-contact)
  * [4 Gets tasks by filter](#54-gets-tasks-by-filter)
  * [5 Get task by ID](#55-get-task-by-ID)
  * [6 Delete task by ID](#56-delete-task-by-ID)
  * [7 Update task by ID](#56-update-task-by-ID)
  

Requirements
------------

1. C# 3.0 with .NET 3.5 or later.

2. Any JSON library. There's many available over the internet. One of them is [Json.NET] (http://james.newtonking.com/pages/json-net.aspx).

3. Setting Domain Name and Api Key

![Finding Domain name, email and api key] (https://raw.githubusercontent.com/agilecrm/c-sharp-api/master/AgileCRMapi.png)

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

- [**About properties JSON**](https://github.com/agilecrm/rest-api/blob/master/README.md#properties-json)

- [**Properties JSON Complete Example**](https://github.com/agilecrm/rest-api/blob/master/README.md#properties-json-complete-example)

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

## 4. Note
#### 4.1 Create a note and relate that to contacts

```javascript
string noteDetail = "{\"subject\":\"Note subject hello \",\"description\":\"Note description gone successfull after contact paid us\", \"contact_ids\":[\"5696538890207232\", \"5758948741218306\"]}";

string s1 = agileCRM("notes", "POST", noteDetail,"application/json");

Console.Write(s1);
```

#### 4.2 Add note to a contact using email ID

```javascript
string noteDetailByEmail ="email=agilecrm@test.com123&note={\"subject\":\"test\",\"description\":\"testing description\"}";

string result = agileCRM("contacts/email/note/add", "POST", noteDetailByEmail,"application/x-www-form-urlencoded");

Console.WriteLine(result);
```

#### 4.3 Gets notes related to specific contact

```javascript
string s1 = agileCRM("contacts/5688267051630592/notes", "GET", null,"application/json");

Console.WriteLine(s1);
```

#### 4.4 Delete a specific note from specific contact

```javascript
string s1 = agileCRM("contacts/5688267051630592/notes/5688267051630600", "DELETE", null,"application/json");
```

#### 4.5 Create note to a deal

```javascript
string noteDetail = "{\"subject\":\"Note subject hello \",\"description\":\"Note description gone successfull after contact paid us\", \"deal_ids\":[\"5728337217454080\", \"5758948741218306\"]}";
	
string s1 = agileCRM("opportunity/deals/notes", "POST", noteDetail,"application/json");

Console.Write(s1);
```

#### 4.6 Update note to a deal

```javascript
string noteDetail = "{\"id\":\"5697894489260032\",\"subject\":\"Note subject hello \",\"description\":\"Note description gone successfull after contact paid us\", \"deal_ids\":[\"5728337217454080\", \"5758948741218306\"]}";

string s1 = agileCRM("opportunity/deals/notes", "PUT", noteDetail,"application/json");

Console.Write(s1);
```

#### 4.7 Gets notes related to specific deal

```javascript
string s1 = agileCRM("opportunity/5728337217454080/notes", "GET", null,"application/json");

Console.WriteLine(s1);
```

## 5. Task
#### 5.1 Create a task and relate that to contacts

- [**Reference : **](https://github.com/agilecrm/rest-api#54-create-a-task)

```javascript
string taskDetail = "{\"progress\": \"29\",\"is_complete\": \"false\",\"subject\": \"Need to contact vendor\",\"type\": \"MEETING\",\"due\": 1459319400,\"task_ending_time\": \"12:00\",\"priority_type\": \"HIGH\",\"status\": \"YET_TO_START\",\"taskDescription\": \"This is very important. We need to discuss with few vendors about the product.\",\"contacts\": [\"5688066194800640\"],\"deal_ids\": [\"5638839829790720\"]}";

string s1 = agileCRM("tasks", "POST", taskDetail,"application/json");

Console.Write(s1);
```

#### 5.2 Add task to a contact using email ID

- [**Reference : **](https://github.com/agilecrm/rest-api#55-create-a-task-based-on-contact-email)

```javascript
string taskDetail = "{\"progress\": \"29\",\"is_complete\": \"false\",\"subject\": \"Need to contact vendor\",\"type\": \"MEETING\",\"due\": 1459319400,\"task_ending_time\": \"12:00\",\"priority_type\": \"HIGH\",\"status\": \"YET_TO_START\",\"taskDescription\": \"This is very important. We need to discuss with few vendors about the product.\"}";

string s1 = agileCRM("tasks/email/samson@walt.ltd", "POST", taskDetail,"application/json");

Console.Write(s1);
```

#### 5.3 Gets tasks related to specific contact

```javascript

string s1 = agileCRM("contacts/5688066194800640/tasks", "GET", null,"application/json");

// ID is contact ID
Console.Write(s1);
```

#### 5.4 Gets tasks by filter

- [**Reference : **](https://github.com/agilecrm/rest-api#52-get-the-list-of-tasks-based-on-given-filters)

```javascript

string s1 = agileCRM("tasks/based?pending=true&criteria=CATEGORY&type=EMAIL&page_size=10", "GET", null,"application/json");

Console.Write(s1);
```

#### 5.5 Get task by ID

```javascript

string s1 = agileCRM("tasks/5752673240350720", "GET", null,"application/json");

Console.Write(s1);
```

#### 5.6 Delete task by ID

```javascript

string s1 = agileCRM("tasks/5752673240350720", "DELETE", null,"application/json");

Console.Write(s1);
```

#### 5.7 Update task by ID

- [**Reference : **](https://github.com/agilecrm/rest-api#56-update-a-task-partial-update)

```javascript

string updateTaskDetail = "{\"id\": \"5752673240350720\",\"subject\": \"sample\",\"due\": 1458941500,\"type\":\"EMAIL\"}";

string s1 = agileCRM("tasks/partial-update", "PUT", updateTaskDetail,"application/json");

Console.WriteLine(s1);
```
