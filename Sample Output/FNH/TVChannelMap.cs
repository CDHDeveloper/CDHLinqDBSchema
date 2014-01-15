using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class TVChannelMap : ClassMap<TVChannel>
	{
		public TVChannelMap()
		{
			Table("[NTeract].[].[TVChannel]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.TVStation).Column("StationId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.ChannelNumber, "ChannelNumber");
			Map(x => x.IsHD, "IsHD");

		}
	}
}
