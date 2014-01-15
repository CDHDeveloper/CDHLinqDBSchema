using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.EBook")]
	class EBook
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="Title", DBType="nvarchar(MAX)"  )]
		public string Title { get; set; }

		[Column(Name="ThumbURI", DBType="nvarchar(MAX)"  )]
		public string ThumbURI { get; set; }

		[Column(Name="DateAdded", DBType="datetime"  )]
		public DateTime DateAdded { get; set; }

		[Column(Name="LastUpdate", DBType="datetime"  )]
		public DateTime LastUpdate { get; set; }

	}
}
