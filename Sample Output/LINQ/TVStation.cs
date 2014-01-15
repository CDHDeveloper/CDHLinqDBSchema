using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.TVStation")]
	class TVStation
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="Name", DBType=""  )]
		public string Name { get; set; }

		[Column(Name="NetworkId", DBType="int"  )]
		public int NetworkId { get; set; }

		[Column(Name="HasHD", DBType="bit"  )]
		public bool HasHD { get; set; }

		[Column(Name="HDOnly", DBType="bit"  )]
		public bool HDOnly { get; set; }

		[Column(Name="URI", DBType="nvarchar(MAX)"  )]
		public string URI { get; set; }

	}
}
