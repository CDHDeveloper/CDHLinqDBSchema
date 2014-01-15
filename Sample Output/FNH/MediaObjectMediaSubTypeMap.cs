using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class MediaObjectMediaSubTypeMap : ClassMap<MediaObjectMediaSubType>
	{
		public MediaObjectMediaSubTypeMap()
		{
			Table("[NTeract].[].[MediaObjectMediaSubType]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.MediaObject).Column("MediaObjectId");
			References(x => x.MediaSubType).Column("MediaSubTypeId");
			Map(x => x.Id, "Id").Not.Nullable();

		}
	}
}
