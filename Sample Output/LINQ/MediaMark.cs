using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.MediaMark")]
	class MediaMark
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="Name", DBType="nvarchar(50)"  )]
		public string Name { get; set; }

		[Column(Name="Position", DBType="int"  )]
		public int Position { get; set; }

		[Column(Name="UserId", DBType="int"  )]
		public int UserId { get; set; }

		[Column(Name="MediaObjectMediaItemId", DBType="int"  )]
		public int MediaObjectMediaItemId { get; set; }

	}
}
