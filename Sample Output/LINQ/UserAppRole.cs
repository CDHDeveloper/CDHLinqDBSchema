using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.UserAppRole")]
	class UserAppRole
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="UserId", DBType="int"  )]
		public int UserId { get; set; }

		[Column(Name="RoleId", DBType="int"  )]
		public int RoleId { get; set; }

	}
}
