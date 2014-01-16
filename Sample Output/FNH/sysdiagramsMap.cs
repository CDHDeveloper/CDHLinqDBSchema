using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class sysdiagramsMap : ClassMap<sysdiagrams>
	{
		public sysdiagramsMap()
		{
			Table("[NTeract].[dbo].[sysdiagrams]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.name, "name").Not.Nullable().Length(128);
			Map(x => x.principal_id, "principal_id").Not.Nullable();
			Map(x => x.diagram_id, "diagram_id").Not.Nullable();
			Map(x => x.version, "version");
			Map(x => x.definition, "definition");

		}
	}
}
