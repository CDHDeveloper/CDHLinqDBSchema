using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.PodCastEpisode")]
	class PodCastEpisode
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="PodCastId", DBType="int"  )]
		public int PodCastId { get; set; }

		[Column(Name="URI", DBType="nvarchar(MAX)"  )]
		public string URI { get; set; }

		[Column(Name="PostedDate", DBType="datetime"  )]
		public DateTime PostedDate { get; set; }

		[Column(Name="Description", DBType="nvarchar(250)"  )]
		public string Description { get; set; }

		[Column(Name="FileSize", DBType="int"  )]
		public int FileSize { get; set; }

		[Column(Name="Duration", DBType="int"  )]
		public int Duration { get; set; }

		[Column(Name="MediaObjectId", DBType="int"  )]
		public int MediaObjectId { get; set; }

	}
}
