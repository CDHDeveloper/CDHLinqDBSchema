using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.TVEpisodeMediaObject")]
	class TVEpisodeMediaObject
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="TVEpisodeId", DBType="int"  )]
		public int TVEpisodeId { get; set; }

		[Column(Name="MediaObjectId", DBType="int"  )]
		public int MediaObjectId { get; set; }

	}
}
