using CoreBusiness.ShopByShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UseCases.ShopByShop.InterfacesRepositories;

namespace Plugins.ShopByShop.InMemory.Services
{
    public class TrackServiceInMemory : ITrackRepository
    {
        #region Private Fields
        private TracksJson tracksJsonFake;
        private List<TrackItem> tracksFake;
        #endregion
        // ---
        #region Public Methods
        public TrackServiceInMemory()
        {
            var trackItem_1 = new TrackItem
            {
                Id = 1,
                Code = "code 1",
                RecipientId = 1,
                UserName = "user_name 1",
                Surname = "surname 1",
                Pvz = "1",
                Store = "store 1",
                Wait = 1,
                Agree = 1,
                DeliveryType = 1,

                Products = new List<Product> {
                    new Product
                    {
                        Name = "name 1",
                        Count = 1,
                        Link = "link 1",
                        Price = 1
                    }
                }
            };
            var trackItem_2 = new TrackItem
            {
                Id = 1,
                Code = "code 1",
                RecipientId = 1,
                UserName = "user_name 1",
                Surname = "surname 1",
                Pvz = "1",
                Store = "store 1",
                Wait = 1,
                Agree = 1,
                DeliveryType = 1,

                Products = new List<Product> {
                    new Product
                    {
                        Name = "name 1",
                        Count = 1,
                        Link = "link 1",
                        Price = 1
                    }
                }
            };
            var trackItem_3 = new TrackItem
            {
                Id = 1,
                Code = "code 1",
                RecipientId = 1,
                UserName = "user_name 1",
                Surname = "surname 1",
                Pvz = "1",
                Store = "store 1",
                Wait = 1,
                Agree = 1,
                DeliveryType = 1,

                Products = new List<Product> {
                    new Product
                    {
                        Name = "name 1",
                        Count = 1,
                        Link = "link 1",
                        Price = 1
                    }
                }
            };

            tracksFake = new List<TrackItem>() 
                { trackItem_1, trackItem_2, trackItem_3 };

            tracksJsonFake = new TracksJson
            {
                Success = true,
                Data = new TrackJsonData
                {
                    Tracks = new Tracks { Data = tracksFake }
                },
                Message = ""
            };
        }

#pragma warning disable CS1998
        public async Task<int?> CreateTrackAsync(TrackItem trackItem)
        {
            if (tracksFake.Any(x => x.Id.Equals(trackItem.Id))) 
                return null;

            if (tracksFake != null && tracksFake.Count > 0)
            {
                var maxId = tracksFake.Max(x => x.Id);
                trackItem.Id = maxId + 1;
            }
            else
            {
                trackItem.Id = 1;
            }

            tracksFake?.Add(trackItem);

            return trackItem.Id;
        }

        public async Task<bool> DeleteTrackAsync(int Id)
        {
            var item = await GetTrackByIdAsync(Id);
            if (item == null)
            {
                return false;
            } 
            else
            {
                tracksFake?.Remove(item);
                return true;                
            }
        }

        public async Task<IEnumerable<TrackItem>?> GetTracksAsync()
        {
            return tracksJsonFake?.Data?.Tracks?.Data;
        }

        public async Task<TrackItem?> ShowInfoTrackAsync(int Id)
        {
            return await GetTrackByIdAsync(Id);
        }

        public async Task<bool> UpdateTrackAsync(TrackItem newTrack)
        {
            var trackToUpdate = await GetTrackByIdAsync(newTrack.Id ?? 0);

            if (trackToUpdate == null)
            {
                return false;
            }            
            else
            {
                trackToUpdate.Code = newTrack.Code;
                trackToUpdate.RecipientId = newTrack.RecipientId;
                trackToUpdate.UserName = newTrack.UserName;
                trackToUpdate.Surname = newTrack.Surname;
                trackToUpdate.Pvz = newTrack.Pvz;
                trackToUpdate.Comment = newTrack.Comment;
                trackToUpdate.Store = newTrack.Store;
                trackToUpdate.Wait = newTrack.Wait;
                trackToUpdate.Agree = newTrack.Agree;
                trackToUpdate.DeliveryType = newTrack.DeliveryType;
                trackToUpdate.Insurence = newTrack.Insurence;
                trackToUpdate.Photo = newTrack.Photo;
                trackToUpdate.CheckSize = newTrack.CheckSize;
                trackToUpdate.Packing = newTrack.Packing;

                trackToUpdate.Products = newTrack.Products;

                return true;
            }
        }

        public async Task<bool> RecoverTrackAsync(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion
        // ---
        #region Private Methods
#pragma warning disable CS8766 // ToDo: warning CS8766
        private async Task<TrackItem?> GetTrackByIdAsync(int Id)
        {
            if (Id > 0) return null;
            else return tracksFake?.FirstOrDefault(x => x.Id == Id);
        }

#pragma warning restore CS8766
        #endregion

#pragma warning restore CS1998
    }
}
