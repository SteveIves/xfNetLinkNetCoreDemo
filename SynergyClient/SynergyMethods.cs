// Generated on 29-Sep-2021 05:06:46 by gencs v0.0.0.0
// 
// The contents of this file are auto-generated. Only add modifications to the end of this file.
// Any modifications will be lost when the file is re-generated.
// 
using System;
using System.Collections;
using System.Reflection;
#if POOLING
using System.EnterpriseServices;
#endif
using Synergex.xfnlnet;
namespace SynergyClient
{
/// <summary>
/// Procedural Interface Class SynergyClient
/// </summary>
#if POOLING
	[ObjectPooling()]
	public partial class SynergyMethods : ServicedComponent, ISynergyMethods
#else
	public partial class SynergyMethods : ISynergyMethods
#endif
	{
		/// <summary>
		/// constructor
		/// </summary>
		public SynergyMethods()
		{
			m_xfnet = new XFNet(this);
			m_xfnet.initialize();
		}
#if NET || NETSTANDARD
		/// <summary>
		/// constructor
		/// </summary>
		public SynergyMethods(Microsoft.Extensions.Configuration.IConfiguration configuration)
		{
			m_xfnet = new XFNet(this, configuration);
			m_xfnet.initialize();
		}
#endif
#if POOLING
		/// <summary>
		/// release method for pooling
		/// </summary>
		~SynergyMethods()
		{
			Dispose(false);
		}
		private new void Dispose(Boolean disposing)
		{
			m_xfnet.disconnect(disposing);
		}
#endif
		/// <summary>
		/// Copies a file on the server
		/// </summary>
		/// <param name="fromFile"></param>
		/// <param name="toFile"></param>
		/// <param name="ok"></param>
		/// <param name="errorMessage"></param>
		public void CopyFile (
			[XFAttr(type=XFAttr.xftype.STRING,size=0)]string fromFile
			,[XFAttr(type=XFAttr.xftype.STRING,size=0)]string toFile
			,[XFAttr(type=XFAttr.xftype.INTEGER,size=4,dir=XFAttr.xfdir.OUT)]out int ok
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]out string errorMessage
		)
		{
			object[] pa = new object[4];
			pa[0]=fromFile;
			pa[1]=toFile;
			m_xfnet.callUserMethod("CopyFile",ref pa);
			ok=(int)pa[2];
			errorMessage=(string)pa[3];
		}
		/// <summary>
		/// Returns an address record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="AddressID">Passed address ID</param>
		/// <param name="Address">Returned address structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status GetAddressForUpdate (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int AddressID
			,[XFAttr(dir=XFAttr.xfdir.OUT)]out Address Address
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.OUT)]out byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]out string Message
		)
		{
			object[] pa = new object[5];
			pa[0]=CustomerID;
			pa[1]=AddressID;
			Address xfStr2 = new Address();
			pa[2] = xfStr2;
			pa[3] = new byte[0];
			Method_status ret=(Method_status)m_xfnet.callUserMethod("GetAddressForUpdate",ref pa);
			Address=(Address)pa[2];
			GRFA=(byte[])pa[3];
			Message=(string)pa[4];
			return ret;
		}
		/// <summary>
		/// Returns a collection of all customers
		/// </summary>
		/// <param name="Customers">Returned ArrayList of boxed customer structures</param>
		public void GetAllCustomers (
			[XFAttr(size=118,sysal=true,dir=XFAttr.xfdir.OUT)]out ArrayList Customers
		)
		{
			object[] pa = new object[1];
			ArrayList tmpAl0 = new ArrayList();
			Customer xfStr0 = new Customer();
			tmpAl0.Add(xfStr0);
			pa[0] = tmpAl0;
			m_xfnet.callUserMethod("GetAllCustomers",ref pa);
			Customers=(ArrayList)pa[0];
		}
		/// <summary>
		/// Returns a contact record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="ContactID">Passed contact ID</param>
		/// <param name="Contact">Returned contact structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status GetContactForUpdate (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int ContactID
			,[XFAttr(dir=XFAttr.xfdir.OUT)]out Contact Contact
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.OUT)]out byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]out string Message
		)
		{
			object[] pa = new object[5];
			pa[0]=CustomerID;
			pa[1]=ContactID;
			Contact xfStr2 = new Contact();
			pa[2] = xfStr2;
			pa[3] = new byte[0];
			Method_status ret=(Method_status)m_xfnet.callUserMethod("GetContactForUpdate",ref pa);
			Contact=(Contact)pa[2];
			GRFA=(byte[])pa[3];
			Message=(string)pa[4];
			return ret;
		}
		/// <summary>
		/// Returns a collection of addresses for a customer
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Addresses">Returned ArrayList of boxed address structures</param>
		public void GetCustomerAddresses (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(size=250,sysal=true,dir=XFAttr.xfdir.OUT)]out ArrayList Addresses
		)
		{
			object[] pa = new object[2];
			pa[0]=CustomerID;
			ArrayList tmpAl1 = new ArrayList();
			Address xfStr1 = new Address();
			tmpAl1.Add(xfStr1);
			pa[1] = tmpAl1;
			m_xfnet.callUserMethod("GetCustomerAddresses",ref pa);
			Addresses=(ArrayList)pa[1];
		}
		/// <summary>
		/// Returns a collection of contacts for a customer
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Contacts">Returned ArrayList of boxed contact structures</param>
		public void GetCustomerContacts (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(size=691,sysal=true,dir=XFAttr.xfdir.OUT)]out ArrayList Contacts
		)
		{
			object[] pa = new object[2];
			pa[0]=CustomerID;
			ArrayList tmpAl1 = new ArrayList();
			Contact xfStr1 = new Contact();
			tmpAl1.Add(xfStr1);
			pa[1] = tmpAl1;
			m_xfnet.callUserMethod("GetCustomerContacts",ref pa);
			Contacts=(ArrayList)pa[1];
		}
		/// <summary>
		/// Returns a customer record and current GRFA
		/// </summary>
		/// <param name="CustomerID">Passed customer ID</param>
		/// <param name="Customer">Returned customer structure</param>
		/// <param name="GRFA">Returned current GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status GetCustomerForUpdate (
			[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int CustomerID
			,[XFAttr(dir=XFAttr.xfdir.OUT)]out Customer Customer
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.OUT)]out byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]out string Message
		)
		{
			object[] pa = new object[4];
			pa[0]=CustomerID;
			Customer xfStr1 = new Customer();
			pa[1] = xfStr1;
			pa[2] = new byte[0];
			Method_status ret=(Method_status)m_xfnet.callUserMethod("GetCustomerForUpdate",ref pa);
			Customer=(Customer)pa[1];
			GRFA=(byte[])pa[2];
			Message=(string)pa[3];
			return ret;
		}
		/// <summary>
		/// Updated a contact record
		/// </summary>
		/// <param name="Contact">Contact structure</param>
		/// <param name="GRFA">Previous GRFA</param>
		/// <param name="Message">Returned message text for non success status</param>
		/// <returns>Return value defined by METHOD_STATUS enumeration</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status UpdateContact (
			[XFAttr(dir=XFAttr.xfdir.INOUT)]ref Contact Contact
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.INOUT)]ref byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]out string Message
		)
		{
			object[] pa = new object[3];
			pa[0]=Contact;
			pa[1]=GRFA;
			Method_status ret=(Method_status)m_xfnet.callUserMethod("UpdateContact",ref pa);
			Contact=(Contact)pa[0];
			GRFA=(byte[])pa[1];
			Message=(string)pa[2];
			return ret;
		}
		/// <summary>
		/// Updated a customer record
		/// </summary>
		/// <param name="Customer">Customer structure</param>
		/// <param name="GRFA">Previous GRFA</param>
		/// <param name="Message">Returned error message text if return status is
		/// not METHOD_STATUS.SUCCESS</param>
		/// <returns>Returns a member of the METHOD_STATUS enumeration
		/// to indicate completion status</returns>
		[XFAttr(type=XFAttr.xftype.ENUM,size=4)]
		public Method_status UpdateCustomer (
			[XFAttr(dir=XFAttr.xfdir.INOUT)]ref Customer Customer
			,[XFAttr(type=XFAttr.xftype.BINARYARRAY,size=0,dir=XFAttr.xfdir.INOUT)]ref byte[] GRFA
			,[XFAttr(type=XFAttr.xftype.STRING,size=0,dir=XFAttr.xfdir.OUT)]out string Message
		)
		{
			object[] pa = new object[3];
			pa[0]=Customer;
			pa[1]=GRFA;
			Method_status ret=(Method_status)m_xfnet.callUserMethod("UpdateCustomer",ref pa);
			Customer=(Customer)pa[0];
			GRFA=(byte[])pa[1];
			Message=(string)pa[2];
			return ret;
		}
		#region xfnlnet support methods
		/// <summary>
		/// connect to xfServerPlus
		/// </summary>
		public void connect()
		{
			m_xfnet.connect();
		}
		/// <summary>
		/// xfServerPlus one parameter connect
		/// <param name="scl">security compliance level value</param>
		/// </summary>
		public void connect(int scl)
		{
			m_xfnet.connect(scl);
		}
		/// <summary>
		/// xfServerPlus four parameter connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="minPort">minport number</param>
		/// <param name="maxPort">maxport number</param>
		public void connect(string hostIP, int hostPort, int minPort, int maxPort)
		{
			m_xfnet.connect(hostIP, hostPort, minPort, maxPort);
		}
		/// <summary>
		/// xfServerPlus five parameter connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="minPort">minport number</param>
		/// <param name="maxPort">maxport number</param>
		/// <param name="scl">security compliance level value</param>
		public void connect(string hostIP, int hostPort, int minPort, int maxPort, int scl)
		{
			m_xfnet.connect(hostIP, hostPort, minPort, maxPort, scl);
		}
		/// <summary>
		/// xfServerPlus host and port connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		public void connect(string hostIP, int hostPort)
		{
			m_xfnet.connect(hostIP, hostPort);
		}
		/// <summary>
		/// xfServerPlus host and port and scl connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="scl">security compliance level value</param>
		public void connect(string hostIP, int hostPort, int scl)
		{
			m_xfnet.connect(hostIP, hostPort, scl);
		}
		/// <summary>
		/// disconnect from xfServerPlus
		/// </summary>
		public void disconnect()
		{
			m_xfnet.disconnect();
		}
		/// <summary>
		/// initialize a debug session
		/// </summary>
		/// <param name="hexip">IP address</param>
		/// <param name="port">port number</param>
		public void debugInit(ref string hexip, ref int port)
		{
			m_xfnet.debugInit(ref hexip, ref port);
		}
		/// <summary>
		/// start a debug session of xfServerPlus
		/// </summary>
		public void debugStart()
		{
			m_xfnet.debugStart(0);
		}
		/// <summary>
		/// start a debug session of xfServerPlus with scl
		/// </summary>
		public void debugStart(int scl)
		{
			m_xfnet.debugStart(scl);
		}
#if !POOLING
		/// <summary>
		/// get the object's xfServerPlus connection
		/// </summary>
		/// <returns>xfServerPlus connection</returns>
		public object getConnect()
		{
			return m_xfnet.getConnect();
		}
		/// <summary>
		/// share the provided connection
		/// </summary>
		/// <param name="connect">connection to share</param>
		public void shareConnect(object connect)
		{
			m_xfnet.shareConnect(connect);
		}
#endif
		/// <summary>
		/// set the call timeout in seconds
		/// </summary>
		/// <param name="seconds">timeout in seconds</param>
		public void setCallTimeout(int seconds)
		{
			m_xfnet.setCallTimeout(seconds);
		}
		/// <summary>
		/// set the user string
		/// </summary>
		/// <param name="userString">The user string</param>
		public void setUserString(string userString)
		{
			m_xfnet.setUserString(userString);
		}
		/// <summary>
		/// get the user string 
		/// </summary>
		/// <returns>User String</returns>
		public string getUserString()
		{
			return m_xfnet.getUserString();
		}
		/// <summary>
		/// indicate if an object can be put back into the pool
		/// </summary>
		/// <returns>true if object can be returned to pool</returns>
		[XFAttr(type=XFAttr.xftype.INTEGER, size=1)]
#if POOLING
		protected override bool CanBePooled()
#else
		public bool CanBePooled()
#endif
		{
			bool ret = m_xfnet.CanBePooled();
			return ret;
		}
		#endregion
		private XFNet m_xfnet = null;
	}
}
