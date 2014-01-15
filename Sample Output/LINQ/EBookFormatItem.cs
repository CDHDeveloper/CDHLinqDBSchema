using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.EBookFormatItem")]
	class EBookFormatItem
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="EBookId", DBType="int"  )]
		public int EBookId { get; set; }

		[Column(Name="MediaObjectId", DBType="int"  )]
		public int MediaObjectId { get; set; }

		[Column(Name="FormatName", DBType="nvarchar(50)"  )]
		public string FormatName { get; set; }

	}
}
