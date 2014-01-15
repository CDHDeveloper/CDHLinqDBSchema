using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
public class EBookMap : ClassMap<EBook>
}
	public EBookMap()
{
		Table("[NTeract].[].[EBook]");
		Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
		Map(x => x.Id, "Id").Not.Nullable();
		Map(x => x.Title, "Title");
		Map(x => x.ThumbURI, "ThumbURI");
		Map(x => x.DateAdded, "DateAdded");
		Map(x => x.LastUpdate, "LastUpdate");
		HasMany(x => x.EBookFormatItems);
		HasMany(x => x.EBookInfos);
	}
}
