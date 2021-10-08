// Generated on 08-Oct-2021 03:12:52 by gencs v0.0.0.0
// 
// The contents of this file are auto-generated. Only add modifications to the end of this file.
// Any modifications will be lost when the file is re-generated.
// 
using System;
using System.Collections;
using System.Reflection;
using Synergex.xfnlnet;
namespace SynergyClient
{
/// <summary>
/// Interface SynergyClient
/// </summary>
#if POOLING
	public interface ISynergyMethods : IDisposable
#else
	public interface ISynergyMethods
#endif
	{
		/// <summary>
		/// Copies a file on the server
		/// </summary>
		/// <param name="fromFile"></param>
		/// <param name="toFile"></param>
		/// <param name="ok"></param>
		/// <param name="errorMessage"></param>
		void CopyFile (
			string fromFile
			,string toFile
			,out int ok
			,out string errorMessage
		);
		/// <summary>
		/// Returns an address record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="AddressID">Passed address ID</param>
		/// <param name="Address">Returned address structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		Method_status GetAddressForUpdate (
			int CustomerID
			,int AddressID
			,out Address Address
			,out byte[] GRFA
			,out string Message
		);
		/// <summary>
		/// Returns a collection of all customers
		/// </summary>
		/// <param name="Customers">Returned ArrayList of boxed customer structures</param>
		void GetAllCustomers (
			out ArrayList Customers
		);
		/// <summary>
		/// Returns a contact record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="ContactID">Passed contact ID</param>
		/// <param name="Contact">Returned contact structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		Method_status GetContactForUpdate (
			int CustomerID
			,int ContactID
			,out Contact Contact
			,out byte[] GRFA
			,out string Message
		);
		/// <summary>
		/// Returns a collection of addresses for a customer
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Addresses">Returned ArrayList of boxed address structures</param>
		void GetCustomerAddresses (
			int CustomerID
			,out ArrayList Addresses
		);
		/// <summary>
		/// Returns a collection of contacts for a customer
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Contacts">Returned ArrayList of boxed contact structures</param>
		void GetCustomerContacts (
			int CustomerID
			,out ArrayList Contacts
		);
		/// <summary>
		/// Returns a customer record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Customer">Returned customer structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		Method_status GetCustomerForUpdate (
			int CustomerID
			,out Customer Customer
			,out byte[] GRFA
			,out string Message
		);
		/// <summary>
		/// Updated a contact record
		/// </summary>
		/// <param name="Contact">Contact structure</param>
		/// <param name="GRFA">Previous GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		Method_status UpdateContact (
			ref Contact Contact
			,ref byte[] GRFA
			,out string Message
		);
		/// <summary>
		/// Updated a customer record
		/// </summary>
		/// <param name="Customer">Customer structure</param>
		/// <param name="GRFA">Previous GRFA</param>
		/// <param name="Message">Returned error message text if return status is
		/// not METHOD_STATUS.SUCCESS</param>
		/// <returns>Returns a member of the METHOD_STATUS enumeration
		/// to indicate completion status</returns>
		Method_status UpdateCustomer (
			ref Customer Customer
			,ref byte[] GRFA
			,out string Message
		);
		#region xfnlnet support methods
		/// <summary>
		/// connect to xfServerPlus
		/// </summary>
		void connect();
		/// <summary>
		/// connect to xfServerPlus with scl
		/// </summary>
		/// <param name="scl">security compliance level value</param>
		void connect(int scl);
		/// <summary>
		/// xfServerPlus four parameter connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="minPort">minport number</param>
		/// <param name="maxPort">maxport number</param>
		void connect(string hostIP, int hostPort, int minPort, int maxPort);
		/// <summary>
		/// xfServerPlus four parameter connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="minPort">minport number</param>
		/// <param name="maxPort">maxport number</param>
		/// <param name="scl">security compliance level value</param>
		void connect(string hostIP, int hostPort, int minPort, int maxPort, int scl);
		/// <summary>
		/// xfServerPlus host and port connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		void connect(string hostIP, int hostPort);
		/// <summary>
		/// xfServerPlus host and port connect and scl
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="scl">security compliance level value</param>
		void connect(string hostIP, int hostPort, int scl);
		/// <summary>
		/// disconnect from xfServerPlus
		/// </summary>
		void disconnect();
		/// <summary>
		/// initialize a debug session
		/// </summary>
		/// <param name="hexip">IP address</param>
		/// <param name="port">port number</param>
		void debugInit(ref string hexip, ref int port);
		/// <summary>
		/// start a debug session of xfServerPlus
		/// </summary>
		void debugStart();
		/// <summary>
		/// start a debug session of xfServerPlus with scl
		/// <param name="scl">security compliance level value</param>
		/// </summary>
		void debugStart(int scl);
#if !POOLING
		/// <summary>
		/// get the object's xfServerPlus connection
		/// </summary>
		/// <returns>xfServerPlus connection</returns>
		object getConnect();
		/// <summary>
		/// share the provided connection
		/// </summary>
		/// <param name="connect">connection to share</param>
		void shareConnect(object connect);
#endif
		/// <summary>
		/// set the call timeout in seconds
		/// </summary>
		/// <param name="seconds">timeout in seconds</param>
		void setCallTimeout(int seconds);
		/// <summary>
		/// set the user string
		/// </summary>
		/// <param name="userString">The user string</param>
		void setUserString(string userString);
		/// <summary>
		/// get the user string 
		/// </summary>
		/// <returns>User String</returns>
		string getUserString();
		#endregion
	}
}
