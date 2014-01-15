using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.UserGroup")]
	class UserGroup
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false )]
		public int Id { get; set; }

		[Column(Name="UserId", DBType="int NOT NULL " , CanBeNull=false )]
		public int UserId { get; set; }

		[Column(Name="GroupId", DBType="int NOT NULL " , CanBeNull=false )]
		public int GroupId { get; set; }

	}
}
