using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.PodCast")]
	class PodCast
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="URI", DBType="nvarchar(MAX)"  )]
		public string URI { get; set; }

		[Column(Name="Name", DBType="nvarchar(250)"  )]
		public string Name { get; set; }

		[Column(Name="Description", DBType="nvarchar(MAX)"  )]
		public string Description { get; set; }

		[Column(Name="AutoDownload", DBType="bit"  )]
		public bool AutoDownload { get; set; }

		[Column(Name="DateAdded", DBType="datetime"  )]
		public DateTime DateAdded { get; set; }

		[Column(Name="LastUpdate", DBType="datetime"  )]
		public DateTime LastUpdate { get; set; }

		[Column(Name="LastDownload", DBType="datetime"  )]
		public DateTime LastDownload { get; set; }

		[Column(Name="LastChecked", DBType="datetime"  )]
		public DateTime LastChecked { get; set; }

		[Column(Name="ImageURI", DBType="nvarchar(MAX)"  )]
		public string ImageURI { get; set; }

		[Column(Name="IsVidCast", DBType="bit"  )]
		public bool IsVidCast { get; set; }

	}
}
