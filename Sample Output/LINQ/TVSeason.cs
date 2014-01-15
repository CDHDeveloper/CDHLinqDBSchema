using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.TVSeason")]
	class TVSeason
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="SeriesId", DBType="int"  )]
		public int SeriesId { get; set; }

		[Column(Name="SeasonNumber", DBType="int"  )]
		public int SeasonNumber { get; set; }

		[Column(Name="StartDate", DBType="datetime"  )]
		public DateTime StartDate { get; set; }

		[Column(Name="EndDate", DBType="datetime"  )]
		public DateTime EndDate { get; set; }

	}
}
