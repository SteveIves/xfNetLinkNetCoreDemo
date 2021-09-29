 
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : D:\Demos\ClientServerExamples\xfServerPlus\rps\rpsmain.ism
;                 : D:\Demos\ClientServerExamples\xfServerPlus\rps\rpstext.ism
;                 : Version 9.3.1a
;
;  GENERATED      : 01-MAY-2019, 16:08:25
;                 : Version 10.3.3g
;  EXPORT OPTIONS : [ALL] 
 
 
Enumeration ADDRESS_TYPE
   Description "Type of address"
   Members BUSINESS 0, HOME 1, OTHER 2
 
Enumeration METHOD_STATUS
   Description "Remote method status"
   Members SUCCESS 0, INFO_ERROR 1, FATAL_ERROR 2
 
Enumeration PROJECT_STATUS
   Description "Project status"
   Members CREATED 0, QUOTED 1, SIGNED 2, IMPLEMENT 3, POSTPROJECT 4,
          COMPLETE 5
 
Enumeration SCHEDULE_TYPE
   Description "Type of schedule entry"
   Members FREE 0, DEVELOPMENT 10, PROJECT 1, VACATION 2, HOLIDAY 3,
          SICK 4, TESTING 5, MARKETING 6, EDUCATION 7, TRAVEL 8, SPC 9
 
Template T_ADDRESS_ID   Type INTEGER   Size 4
   Description "Address ID"
 
Template T_CONTACT_ID   Type INTEGER   Size 4
   Description "Contact ID"
 
Template T_CONTRACT_ID   Type ALPHA   Size 10
   Description "Contract ID"
 
Template T_CUSTOMER_ID   Type INTEGER   Size 4
   Description "Customer ID"
 
Template T_GRFA   Type ALPHA   Size 10
   Description "Synergy GRFA"
 
Template T_GRFABYTES   Type INTEGER   Size 1   Dimension 10
   Description "Synergy GRFA as a Byte Array"
 
Template T_REPLICATION_KEY   Type ALPHA   Size 20   Script Noview
   Report Noview   Nonamelink
   Description "SQL Replication Timestamp"
 
Template T_USER   Type ALPHA   Size 15
   Description "User name"
 
Structure ADDRESS   DBL ISAM
   Description "Address master"
 
Field ADDRESS_ID   Template T_ADDRESS_ID
 
Field CUSTOMER_ID   Template T_CUSTOMER_ID
 
Field ADDRESS_TYPE   Type ENUM   Size 4   Enum ADDRESS_TYPE
   Description "Type of address"
 
Field ADDRESS1   Type ALPHA   Size 50
   Description "Address Line 1 - Number, Building"
 
Field ADDRESS2   Type ALPHA   Size 50
   Description "Address Line 2 - Number, street"
 
Field ADDRESS3   Type ALPHA   Size 50
   Description "Address Line 3 - Area, locality"
 
Field CITY   Type ALPHA   Size 30
   Description "City"
 
Field POSTAL_CODE   Type ALPHA   Size 10
   Description "Zip or Postal code"
 
Field ZIP   Type DECIMAL   Size 5   Overlay POSTAL_CODE:0
   Description "Zip Code (US Only)"
   Report Just LEFT   Input Just LEFT
 
Field ZIP_EXTEND   Type DECIMAL   Size 4   Overlay POSTAL_CODE:6
   Description "Zip extension (US Only)"
 
Field STATE   Type ALPHA   Size 2
   Description "State, Province or Country"
 
Field COUNTRY   Type ALPHA   Size 2
   Description "Country"
 
Field MAILING_ADDRESS   Type BOOLEAN   Size 4
   Description "This is a mailing address"
 
Field BILLING_ADDRESS   Type BOOLEAN   Size 4
   Description "This is a billing address"
 
Field MAIN_ADDRESS   Type BOOLEAN   Size 4
   Description "This is the main office address"
 
Field SATELLITE_OFFICE   Type BOOLEAN   Size 4
   Description "This is a satellite office address"
 
Field ACTIVE_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date address became active"
 
Field REPLICATION_KEY   Template T_REPLICATION_KEY
 
Key ADDRESS_ID   ACCESS   Order DESCENDING   Dups NO   Compress KEY
   Description "Address ID (primary key)"
   Segment FIELD   ADDRESS_ID  SegType INTEGER  SegOrder DESCENDING
 
Key CUST_ID_ADDRESS_ID   ACCESS   Order ASCENDING   Dups NO
   Description "Customer ID/Address ID"
   Segment FIELD   CUSTOMER_ID  SegType INTEGER
   Segment FIELD   ADDRESS_ID  SegType INTEGER
 
Structure CONTACT   DBL ISAM
   Description "Contact master"
 
Field CONTACT_ID   Template T_CONTACT_ID
   Prompt "Contact ID"   Info Line "Enter or select a contact ID"
   Required
   Drill Method "lookup_contact"   Change Method "validate_contact"
 
Field CUSTOMER_ID   Template T_CUSTOMER_ID
 
Field ADDRESS_ID   Template T_ADDRESS_ID
 
Field SALUTATION   Type ALPHA   Size 5
   Description "Contact salutation"
   Null Allowed
 
Field FIRST_NAME   Type ALPHA   Size 30
   Description "Contact first name"
   Prompt "First name"   Info Line "Enter the contacts first namer"
   Required
 
Field LAST_NAME   Type ALPHA   Size 30
   Description "Contact last name"
   Prompt "Last name"   Info Line "Enter the contacts last name"
   Required
 
Field FRIENDLY_NAME   Type ALPHA   Size 60
   Description "Contact friendly/printable name"
 
Field TITLE   Type ALPHA   Size 25
   Description "Contact title"
 
Field DEPARTMENT   Type ALPHA   Size 15
   Description "Department name"
   Prompt "Department"
   Drill Method "department_loopup"
 
Field WORK_PHONE   Type DECIMAL   Size 12
   Description "Work phone"
 
Field WORK_EXTENSION   Type DECIMAL   Size 6
   Description "Work phone extension"
 
Field MOBILE_PHONE   Type DECIMAL   Size 12
   Description "Mobile phone"
 
Field HOME_PHONE   Type DECIMAL   Size 12
   Description "Home phone"
 
Field FAX   Type DECIMAL   Size 12
   Description "Fax number"
 
Field WEB_SITE   Type ALPHA   Size 50
   Description "Web site"
 
Field EMAIL   Type ALPHA   Size 50
   Description "Email address"
 
Field PICTURE_FILE   Type ALPHA   Size 255
   Description "Path to contact image file"
 
Field MANAGEMENT_CONTACT   Type DECIMAL   Size 1
   Coerced Type BOOLEAN
   Description "Contact has a management role"
 
Field TECHNICAL_CONTACT   Type DECIMAL   Size 1
   Coerced Type BOOLEAN
   Description "Contact has technical role"
 
Field SALES_CONTACT   Type DECIMAL   Size 1   Coerced Type BOOLEAN
   Description "Contact has a role in sales"
 
Field BILLING_CONTACT   Type DECIMAL   Size 1   Coerced Type BOOLEAN
   Description "Contact for billing purposes"
 
Field GENERAL_CONTACT   Type DECIMAL   Size 1   Coerced Type BOOLEAN
   Description "This is a general contact"
 
Field REPLICATION_KEY   Template T_REPLICATION_KEY
 
Field NONAME_001   Type ALPHA   Size 80
   Description "Filler"
 
Key CONTACT_ID   ACCESS   Order DESCENDING   Dups NO
   Description "Contact_ID"
   Segment FIELD   CONTACT_ID  SegType INTEGER  SegOrder DESCENDING
 
Key CUSTID_LAST_FIRST   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 001
   Description "Customer ID / Last name / First Name"
   Segment FIELD   CUSTOMER_ID  SegType INTEGER
   Segment FIELD   LAST_NAME  SegType NOCASE
   Segment FIELD   FIRST_NAME  SegType NOCASE
 
Key LAST_FIRST   ACCESS   Order ASCENDING   Dups YES   Modifiable YES   Krf 002
   Description "Last name / First name"
   Segment FIELD   LAST_NAME  SegType NOCASE
   Segment FIELD   FIRST_NAME  SegType NOCASE
 
Structure CUSTOMER   DBL ISAM
   Description "Customer Master record layout"
 
Field CUSTOMER_ID   Template T_CUSTOMER_ID
 
Field NAME   Type ALPHA   Size 40
   Description "Customer name"
 
Field DATE_CREATED   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date customer was created"
 
Field DATE_MODIFIED   Type DATE   Size 8   Stored YYYYMMDD
   Description "Last modification date"
 
Field STATUS   Type ALPHA   Size 1
   Description "Company status"
 
Field REPLICATION_KEY   Template T_REPLICATION_KEY
 
Field NONAME_001   Type ALPHA   Size 37
   Description "Filler record"
 
Key CUST_ID   ACCESS   Order DESCENDING   Dups NO
   Description "Customer ID (primary key)"
   Segment FIELD   CUSTOMER_ID  SegType INTEGER  SegOrder DESCENDING
 
Key CUST_NAME   ACCESS   Order ASCENDING   Dups NO
   Description "Customer Name"
   Segment FIELD   NAME  SegType ALPHA  SegOrder ASCENDING
 
Structure CUSTOMER_CONTRACT   DBL ISAM
   Description "Customer contracts"
 
Field CUSTOMER_ID   Template T_CUSTOMER_ID
 
Field CONTRACT_ID   Template T_CONTRACT_ID
 
Field ISSUED_BY   Template T_USER
 
Field ISSUED_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date issued"
 
Field SIGNED_BY   Template T_CONTACT_ID
   Description "Customer contact who signed contract"
 
Field SIGNED_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date contract was signed by cont"
 
Field CREATED_BY   Template T_USER
   Description "Contract created by (user name)"
 
Field CREATED_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date contract entered into syste"
 
Field CONTRACT_DOCUMENT   Type ALPHA   Size 255
   Description "Contract file spec"
 
Field REPLICATION_KEY   Template T_REPLICATION_KEY
 
Key CUST_ID_CONTRACT_ID   ACCESS   Order ASCENDING   Dups NO
   Description "Customer ID / Contract ID (primary)"
   Segment FIELD   CUSTOMER_ID  SegType INTEGER
   Segment FIELD   CONTRACT_ID  SegType ALPHA
 
Key CONTRACT_ID   ACCESS   Order ASCENDING   Dups NO
   Description "Contract ID"
   Segment FIELD   CONTRACT_ID  SegType ALPHA
 
Structure CUSTOMER_NOTE   DBL ISAM
   Description "Customer notes file"
 
Field CUSTOMER_ID   Template T_CUSTOMER_ID
 
Field DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date note was created"
 
Field TIME   Type TIME   Size 6   Stored HHMMSS
   Description "Time note was created"
 
Field USERNAME   Template T_USER
 
Field TEXT   Type ALPHA   Size 500
   Description "Note text"
 
Field DATE_DELETED   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date the note deleted"
 
Field REPLICATION_KEY   Template T_REPLICATION_KEY
 
Key CUST_ID_DATETIME   ACCESS   Order DESCENDING   Dups NO
   Description "Customer ID / Date & Time note created"
   Segment FIELD   CUSTOMER_ID  SegType INTEGER  SegOrder DESCENDING
   Segment FIELD   DATE  SegType DECIMAL  SegOrder DESCENDING
   Segment FIELD   TIME  SegType DECIMAL  SegOrder DESCENDING
 
Structure PROJECT   DBL ISAM
   Description "Project master file"
 
Field CUSTOMER_ID   Template T_CUSTOMER_ID
 
Field CONTRACT_ID   Template T_CONTRACT_ID
 
Field CONTRACT_PROJECT_ID   Type DECIMAL   Size 3
   Description "Project # (sequence) within contract"
   Report Just LEFT   Input Just LEFT
 
Field PROJECT_ID   Type ALPHA   Size 13   Overlay CONTRACT_ID:0
   Description "Includes Contract ID & Contract Proj ID"
 
Field DESCRIPTION   Type ALPHA   Size 60
   Description "Short project description"
 
Field START_DATE   Type DECIMAL   Size 8
   Description "Project Start date"
   Report Just LEFT   Input Just LEFT
 
Field START_TIME   Type TIME   Size 4   Stored HHMM
   Description "Time project is set to start"
 
Field END_DATE   Type DECIMAL   Size 8
   Description "Project End date"
   Report Just LEFT   Input Just LEFT
 
Field END_TIME   Type TIME   Size 4   Stored HHMM
   Description "Time project completes"
 
Field CURRENT_STATUS   Type ENUM   Size 4   Enum PROJECT_STATUS
   Description "Project Status"
   Report Just LEFT   Input Just LEFT
 
Field STATUS_DATE   Type DECIMAL   Size 8
   Description "Last status change"
   Report Just LEFT   Input Just LEFT
 
Field LEAD_CONSULTANT   Template T_USER
   Description "Consultant user name"
 
Field COORDINATOR   Template T_USER
   Description "Project coordinator"
 
Field APPROVED_BY_FIRST   Template T_CONTACT_ID
   Description "First approved by contact id"
 
Field APPROVED_BY_LAST   Template T_CONTACT_ID
   Description "Last approved by contact id"
 
Field APPROVED_DATE   Type DECIMAL   Size 8
   Description "(176,183) Date approved by customer"
   Report Just LEFT   Input Just LEFT
 
Field WORK_LOCATION_ID   Template T_ADDRESS_ID
   Description "Location for project execution"
 
Field CREATED_BY   Template T_USER
   Description "Project created by"
 
Field CREATED_DATE   Type DECIMAL   Size 8
   Description "Date project created"
   Report Just LEFT   Input Just LEFT
 
Field MODIFIED_BY   Template T_USER
   Description "Last modified by"
 
Field MODIFIED_DATE   Type DECIMAL   Size 8
   Description "Last modified date"
   Report Just LEFT   Input Just LEFT
 
Field TEXT   Type ALPHA   Size 700
   Description "Long description"
 
Field TEXT_ARRAY   Type ALPHA   Size 70   Dimension 10   Overlay TEXT:0
   Description "Text field overlay"
 
Field REPLICATION_KEY   Type ALPHA   Size 20
   Description "(934,953) SQL Replication Timestamp"
 
Key CUSTID_PROJID   ACCESS   Order ASCENDING   Dups NO
   Description "Customer ID / Project ID (Primary)"
   Segment FIELD   CUSTOMER_ID  SegType INTEGER
   Segment FIELD   PROJECT_ID  SegType ALPHA
 
Key PROJECT_ID   ACCESS   Order ASCENDING   Dups NO
   Description "Project_ID"
   Segment FIELD   PROJECT_ID  SegType ALPHA
 
Key START_DATE   ACCESS   Order ASCENDING   Dups YES
   Description "Date project is slated to begin"
   Segment FIELD   START_DATE  SegType DECIMAL
 
Key LEADCONSULTANT_STARTDATE   ACCESS   Order ASCENDING   Dups YES   Insert END
   Description "Lead consultant / start date"
   Segment FIELD   LEAD_CONSULTANT  SegType ALPHA
   Segment FIELD   START_DATE  SegType DECIMAL
 
Structure SCHEDULE   DBL ISAM
   Description "Consultant and Contractor schedule file"
 
Field USERNAME   Template T_USER
 
Field START_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Start date of schedule entry"
 
Field START_TIME   Type TIME   Size 4   Stored HHMM
   Description "Start time of schedule entry"
 
Field END_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "End date of schedule entry"
 
Field END_TIME   Type TIME   Size 4   Stored HHMM
   Description "End time of schedule entry"
 
Field TYPE   Type ENUM   Size 4   Enum SCHEDULE_TYPE
   Description "Type of schedule entry"
 
Field CONTRACT_ID   Type ALPHA   Size 10
   Description "Project contract id, if a project"
 
Field CONTRACT_PROJ_ID   Type DECIMAL   Size 3
   Description "Project ID of contract, if project"
 
Field PROJECT_ID   Type ALPHA   Size 13   Overlay CONTRACT_ID:0
   Description "Contract & Project sequence number"
 
Field DESCRIPTION   Type ALPHA   Size 60
   Description "Brief description of schedule entry"
 
Field TEXT   Type ALPHA   Size 700
   Description "Long description of schedule entry"
 
Field TEXT_ARRAY   Type ALPHA   Size 70   Dimension 10   Overlay TEXT:0
   Description "Overlay array of schedule text"
 
Key USER_STARTDATE   ACCESS   Order ASCENDING   Dups YES   Insert END
   Description "User / Start Date"
   Segment FIELD   USERNAME  SegType ALPHA
   Segment FIELD   START_DATE  SegType DECIMAL
 
Key STARTDATE   ACCESS   Order ASCENDING   Dups YES   Insert END
   Description "Start date of schedule entry"
   Segment FIELD   START_DATE  SegType DECIMAL
 
Key USER_ENDDATE   ACCESS   Order ASCENDING   Dups YES   Insert END
   Description "Username / end date of sched entry"
   Segment FIELD   USERNAME  SegType ALPHA
   Segment FIELD   END_DATE  SegType DECIMAL
 
Structure USER   DBL ISAM
   Description "System users database"
 
Field USERNAME   Template T_USER
 
Field CONTACT_ID   Type INTEGER   Size 4
   Description "Internal contact ID"
 
Field PASSWORD   Type ALPHA   Size 15   Report Noview
   Description "Password"
 
Field INACTIVE   Type BOOLEAN   Size 4
   Description "Is the user inactive"
 
Field IS_EMPLOYEE   Type BOOLEAN   Size 4
   Description "User is a Synergex employee"
 
Field IS_MANAGER   Type BOOLEAN   Size 4
   Description "User is a manager"
 
Field IS_CONSULTANT   Type BOOLEAN   Size 4
   Description "User is a PSG consultant"
 
Field IS_CONTRACTOR   Type BOOLEAN   Size 4
   Description "User is a contractor"
 
Field IS_SALES   Type BOOLEAN   Size 4
   Description "User is part of sales department"
 
Field REPLICATION_KEY   Template T_REPLICATION_KEY
 
Key USERNAME   ACCESS   Order ASCENDING   Dups NO
   Description "Username (Primary key)"
   Segment FIELD   USERNAME  SegType NOCASE
 
Key CONTACT_ID   ACCESS   Order ASCENDING   Dups NO
   Description "Contact_ID"
   Segment FIELD   CONTACT_ID  SegType INTEGER
 
File ADDRESS   DBL ISAM   "DAT:address.ism"
   Description "Address Master"
   Assign ADDRESS
 
File CONTACT   DBL ISAM   "DAT:contact.ism"
   Description "Contact Master"
   Assign CONTACT
 
File CUSTOMER   DBL ISAM   "DAT:customer.ism"
   Description "Customer Master"
   Assign CUSTOMER
 
File CUSTOMER_CONTRACT   DBL ISAM   "DAT:customer_contract.ism"
   Description "Contract master file"
   Assign CUSTOMER_CONTRACT
 
File CUSTOMER_NOTE   DBL ISAM   "DAT:customer_note.ism"
   Description "Customer Note master"
   Assign CUSTOMER_NOTE
 
File PROJECT   DBL ISAM   "DAT:project.ism"
   Description "Project master file"
   Assign PROJECT
 
File SCHEDULE   DBL ISAM   "DAT:schedule.ism"
   Description "Consultant Schedule master"
   Assign SCHEDULE
 
File USER   DBL ISAM   "dat:user.ism"
   Description "User master"
   Assign USER   ODBC Name USERS
 
