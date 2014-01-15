using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;

namespace CDH
{
	[Database(Name="NTeract")]
	public class NTeractContext
	{
		public Table<MediaType> MediaTypes
		{
			get
			{
				return GetTable<MediaType>();
				}
			}

		public Table<TVSeason> TVSeasons
		{
			get
			{
				return GetTable<TVSeason>();
				}
			}

		public Table<MediaTypeFileType> MediaTypeFileTypes
		{
			get
			{
				return GetTable<MediaTypeFileType>();
				}
			}

		public Table<TVEpisode> TVEpisodes
		{
			get
			{
				return GetTable<TVEpisode>();
				}
			}

		public Table<TVEpisodeMediaObject> TVEpisodeMediaObjects
		{
			get
			{
				return GetTable<TVEpisodeMediaObject>();
				}
			}

		public Table<MediaObject> MediaObjects
		{
			get
			{
				return GetTable<MediaObject>();
				}
			}

		public Table<MediaItem> MediaItems
		{
			get
			{
				return GetTable<MediaItem>();
				}
			}

		public Table<MediaSubType> MediaSubTypes
		{
			get
			{
				return GetTable<MediaSubType>();
				}
			}

		public Table<ObjectType> ObjectTypes
		{
			get
			{
				return GetTable<ObjectType>();
				}
			}

		public Table<TagObject> TagObjects
		{
			get
			{
				return GetTable<TagObject>();
				}
			}

		public Table<MediaObjectMediaItem> MediaObjectMediaItems
		{
			get
			{
				return GetTable<MediaObjectMediaItem>();
				}
			}

		public Table<Group> Groups
		{
			get
			{
				return GetTable<Group>();
				}
			}

		public Table<UserGroup> UserGroups
		{
			get
			{
				return GetTable<UserGroup>();
				}
			}

		public Table<Genre> Genres
		{
			get
			{
				return GetTable<Genre>();
				}
			}

		public Table<TVNetwork> TVNetworks
		{
			get
			{
				return GetTable<TVNetwork>();
				}
			}

		public Table<TVStation> TVStations
		{
			get
			{
				return GetTable<TVStation>();
				}
			}

		public Table<sysdiagrams> sysdiagramss
		{
			get
			{
				return GetTable<sysdiagrams>();
				}
			}

		public Table<MediaObjectFileType> MediaObjectFileTypes
		{
			get
			{
				return GetTable<MediaObjectFileType>();
				}
			}

		public Table<MediaObjectMediaSubType> MediaObjectMediaSubTypes
		{
			get
			{
				return GetTable<MediaObjectMediaSubType>();
				}
			}

		public Table<ContentRating> ContentRatings
		{
			get
			{
				return GetTable<ContentRating>();
				}
			}

		public Table<FileExtension> FileExtensions
		{
			get
			{
				return GetTable<FileExtension>();
				}
			}

		public Table<MediaMark> MediaMarks
		{
			get
			{
				return GetTable<MediaMark>();
				}
			}

		public Table<MediaPlayback> MediaPlaybacks
		{
			get
			{
				return GetTable<MediaPlayback>();
				}
			}

		public Table<MediaViewer> MediaViewers
		{
			get
			{
				return GetTable<MediaViewer>();
				}
			}

		public Table<MediaViewerUIPlatform> MediaViewerUIPlatforms
		{
			get
			{
				return GetTable<MediaViewerUIPlatform>();
				}
			}

		public Table<PodCast> PodCasts
		{
			get
			{
				return GetTable<PodCast>();
				}
			}

		public Table<PodCastEpisode> PodCastEpisodes
		{
			get
			{
				return GetTable<PodCastEpisode>();
				}
			}

		public Table<EBook> EBooks
		{
			get
			{
				return GetTable<EBook>();
				}
			}

		public Table<EBookInfo> EBookInfos
		{
			get
			{
				return GetTable<EBookInfo>();
				}
			}

		public Table<Tag> Tags
		{
			get
			{
				return GetTable<Tag>();
				}
			}

		public Table<User> Users
		{
			get
			{
				return GetTable<User>();
				}
			}

		public Table<AppRole> AppRoles
		{
			get
			{
				return GetTable<AppRole>();
				}
			}

		public Table<UserAppRole> UserAppRoles
		{
			get
			{
				return GetTable<UserAppRole>();
				}
			}

		public Table<UserInfo> UserInfos
		{
			get
			{
				return GetTable<UserInfo>();
				}
			}

		public Table<EBookFormatItem> EBookFormatItems
		{
			get
			{
				return GetTable<EBookFormatItem>();
				}
			}

		public Table<FileTypeFileExtension> FileTypeFileExtensions
		{
			get
			{
				return GetTable<FileTypeFileExtension>();
				}
			}

		public Table<FileExtensionMediaViewer> FileExtensionMediaViewers
		{
			get
			{
				return GetTable<FileExtensionMediaViewer>();
				}
			}

		public Table<TVChannel> TVChannels
		{
			get
			{
				return GetTable<TVChannel>();
				}
			}

		public Table<TVSeries> TVSeriess
		{
			get
			{
				return GetTable<TVSeries>();
				}
			}

		public Table<FileType> FileTypes
		{
			get
			{
				return GetTable<FileType>();
				}
			}

}
