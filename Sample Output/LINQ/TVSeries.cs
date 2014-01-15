using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.TVSeries")]
	class TVSeries
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="Name", DBType="nvarchar(250)"  )]
		public string Name { get; set; }

		[Column(Name="FirstAirDate", DBType="datetime"  )]
		public DateTime FirstAirDate { get; set; }

		[Column(Name="LastAirDate", DBType="datetime"  )]
		public DateTime LastAirDate { get; set; }

		[Column(Name="Ongoing", DBType="bit"  )]
		public bool Ongoing { get; set; }

		[Column(Name="OneTimeShow", DBType="bit"  )]
		public bool OneTimeShow { get; set; }

		[Column(Name="ContentRatingId", DBType="int"  )]
		public int ContentRatingId { get; set; }

		[Column(Name="WebSite", DBType="nvarchar(MAX)"  )]
		public string WebSite { get; set; }

		[Column(Name="IMDBId", DBType="nvarchar(50)"  )]
		public string IMDBId { get; set; }

		[Column(Name="TvDbId", DBType=""  )]
		public string TvDbId { get; set; }

		[Column(Name="NetworkId", DBType="int"  )]
		public int NetworkId { get; set; }

		[Column(Name="Zap2ItId", DBType="int"  )]
		public int Zap2ItId { get; set; }

		[Column(Name="LastUpdated", DBType="datetime"  )]
		public DateTime LastUpdated { get; set; }

	}
}
