using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.MediaPlayback")]
	class MediaPlayback
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="MediaMarkId", DBType="int"  )]
		public int MediaMarkId { get; set; }

		[Column(Name="ModifiedTime", DBType="datetime"  )]
		public DateTime ModifiedTime { get; set; }

	}
}
