using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class EBookFormatItemMap : ClassMap<EBookFormatItem>
	{
		public EBookFormatItemMap()
		{
			Table("[NTeract].[].[EBookFormatItem]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			References(x => x.MediaObject).Column("MediaObjectId");
			References(x => x.EBook).Column("EBookId");
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.FormatName, "FormatName").Length(50);

		}
	}
}
