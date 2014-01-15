using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.sysdiagrams")]
	class sysdiagrams
	{
		[Column(Name="name", DBType="nvarchar(128) NOT NULL " , CanBeNull=false )]
		public string name { get; set; }

		[Column(Name="principal_id", DBType="int NOT NULL " , CanBeNull=false )]
		public int principal_id { get; set; }

		[Column(Name="diagram_id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int diagram_id { get; set; }

		[Column(Name="version", DBType="int"  )]
		public int version { get; set; }

		[Column(Name="definition", DBType="varbinary"  )]
		public byte[] definition { get; set; }

	}
}
