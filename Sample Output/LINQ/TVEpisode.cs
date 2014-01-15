using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.TVEpisode")]
	class TVEpisode
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="SeasonId", DBType="int"  )]
		public int SeasonId { get; set; }

		[Column(Name="Number", DBType="int"  )]
		public int Number { get; set; }

		[Column(Name="Name", DBType="nvarchar(MAX)"  )]
		public string Name { get; set; }

		[Column(Name="AirDate", DBType="datetime"  )]
		public DateTime AirDate { get; set; }

	}
}
