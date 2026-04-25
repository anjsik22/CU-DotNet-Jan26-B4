
using AutoMapper;
using TicketBookingSystem.TripService.DTOs;
using TicketBookingSystem.TripService.Models;
namespace TicketBookingSystem.TripService.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTripDto, Trip>();

            CreateMap<Trip, TripWithItineraryDto>();
        }
    }
}
