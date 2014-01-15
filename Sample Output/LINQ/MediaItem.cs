using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.MediaItem")]
	class MediaItem
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="FileTypeId", DBType="int"  )]
		public int FileTypeId { get; set; }

		[Column(Name="URI", DBType="nvarchar(MAX)"  )]
		public string URI { get; set; }

		[Column(Name="LastUpdate", DBType="datetime"  )]
		public DateTime LastUpdate { get; set; }

	}
}
