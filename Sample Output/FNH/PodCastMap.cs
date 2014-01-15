using System;
using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace CDH.Mapping
{
	public class PodCastMap : ClassMap<PodCast>
	{
		public PodCastMap()
		{
			Table("[NTeract].[].[PodCast]");
			Id(x => x.Id, "CDH.LinqDBSchema.PrimaryKey").GeneratedBy.Identity();
			Map(x => x.Id, "Id").Not.Nullable();
			Map(x => x.URI, "URI");
			Map(x => x.Name, "Name").Length(250);
			Map(x => x.Description, "Description");
			Map(x => x.AutoDownload, "AutoDownload");
			Map(x => x.DateAdded, "DateAdded");
			Map(x => x.LastUpdate, "LastUpdate");
			Map(x => x.LastDownload, "LastDownload");
			Map(x => x.LastChecked, "LastChecked");
			Map(x => x.ImageURI, "ImageURI");
			Map(x => x.IsVidCast, "IsVidCast");
			HasMany(x => x.PodCastEpisodes);

		}
	}
}
