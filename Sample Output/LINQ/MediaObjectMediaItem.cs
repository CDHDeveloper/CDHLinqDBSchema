using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Table(Name="dbo.MediaObjectMediaItem")]
	class MediaObjectMediaItem
	{
		[Column(Name="Id", DBType="int NOT NULL " , CanBeNull=false , IsPrimaryKey=true)]
		public int Id { get; set; }

		[Column(Name="MediaObjectId", DBType="int"  )]
		public int MediaObjectId { get; set; }

		[Column(Name="MediaItemId", DBType="int"  )]
		public int MediaItemId { get; set; }

		[Column(Name="Ordinal", DBType="int"  )]
		public int Ordinal { get; set; }

	}
}
