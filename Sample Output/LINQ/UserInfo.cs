using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.UserInfo")]
	class UserInfo
	{
		[Column(Name="UserId", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int UserId { get; set; }

		[Column(Name="Email", DBType="nvarchar(MAX)"  )]
		public string Email { get; set; }

		[Column(Name="DateAdded", DBType="datetime"  )]
		public DateTime DateAdded { get; set; }

		[Column(Name="LastUpdate", DBType="datetime"  )]
		public DateTime LastUpdate { get; set; }

		[Column(Name="LastLogin", DBType="int"  )]
		public int LastLogin { get; set; }

		[Column(Name="Password", DBType="nvarchar(15)"  )]
		public string Password { get; set; }

		[Column(Name="IsApproved", DBType="bit"  )]
		public bool IsApproved { get; set; }

		[Column(Name="IsLockedOut", DBType="bit"  )]
		public bool IsLockedOut { get; set; }

		[Column(Name="LoginFailures", DBType="int"  )]
		public int LoginFailures { get; set; }

		[Column(Name="LastLockedOut", DBType="datetime"  )]
		public DateTime LastLockedOut { get; set; }

	}
}
