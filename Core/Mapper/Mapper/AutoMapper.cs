using Application.Interfaces.AutoMapper;
using AutoMapper;
using AutoMapper.Internal;
using IMapper = AutoMapper.IMapper;

namespace Mapper.Mapper
{
    public class AutoMapper:Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();
        private IMapper MapperContainer;

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TDestination>(IList<object> source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public void Config<TDestination, TSource>(int depth = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));
            if(typePairs.Any(a=>a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType)&& ignore is null)
                return;
            typePairs.Add(typePair);
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth)
                            .ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
                }

            });
            MapperContainer = config.CreateMapper();
        }
    }
}
