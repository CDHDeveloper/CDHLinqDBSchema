using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.EBookInfo")]
	class EBookInfo
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="EBookId", DBType="int"  )]
		public int EBookId { get; set; }

		[Column(Name="AuthorId", DBType="int"  )]
		public int AuthorId { get; set; }

		[Column(Name="PublisherId", DBType="int"  )]
		public int PublisherId { get; set; }

		[Column(Name="LanguageId", DBType="int"  )]
		public int LanguageId { get; set; }

		[Column(Name="PageCount", DBType="int"  )]
		public int PageCount { get; set; }

		[Column(Name="ThumbURI", DBType="nvarchar(MAX)"  )]
		public string ThumbURI { get; set; }

		[Column(Name="ImageURI", DBType="nvarchar(MAX)"  )]
		public string ImageURI { get; set; }

		[Column(Name="Description", DBType="nvarchar(MAX)"  )]
		public string Description { get; set; }

	}
}
