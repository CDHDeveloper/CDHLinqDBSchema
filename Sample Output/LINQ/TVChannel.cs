using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.TVChannel")]
	class TVChannel
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="StationId", DBType="int"  )]
		public int StationId { get; set; }

		[Column(Name="ChannelNumber", DBType="int"  )]
		public int ChannelNumber { get; set; }

		[Column(Name="IsHD", DBType="bit"  )]
		public bool IsHD { get; set; }

	}
}
