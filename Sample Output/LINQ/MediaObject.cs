using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.MediaObject")]
	class MediaObject
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="Name", DBType="nvarchar(250)"  )]
		public string Name { get; set; }

		[Column(Name="MediaType", DBType="int"  )]
		public int MediaType { get; set; }

		[Column(Name="MediaSubType", DBType="int"  )]
		public int MediaSubType { get; set; }

	}
}
