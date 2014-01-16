using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class GenreMap : ClassMap<Genre>
	{
		public GenreMap()
		{
			Table("[NTeract].[dbo].[Genre]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.Name, "Name").Length(50);
			Map(x => x.Description, "Description").Length(250);

		}
	}
}
