using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;
using NewsAPI.Services;

namespace NewsAPI.Controllers
{
    /// <summary>
    /// This is a sample controller class.
    /// </summary>

    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;
        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }


        /// <summary>
        /// This is a sample GET method.
        /// </summary>
        /// <returns></returns>

        [HttpGet(Name = "GetAnnouncement")]
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> announcements = await _announcementCollectionService.GetAll();
            return Ok(announcements);
        }

        /// <summary>
        /// This is a sample POST method.
        /// </summary>
        /// <returns></returns>

        [HttpPost(Name = "CreateAnnouncement")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Announcement announcement)
        {
            
            if (announcement == null)
            {
                return BadRequest("Announcement is null.");
            }
            
            var isCreated = await _announcementCollectionService.Create(announcement);

            if (isCreated == false)
            {
                return BadRequest("Announcement is not created.");
            }

            return Ok(announcement);
        }

        /// <summary>
        /// This is a sample PUT method.
        /// </summary>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] Announcement announcement, [FromRoute] Guid id)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement is null.");
            }

            //search for the announcement in the existing list
            //if found, update the announcement
            //if not found, return NotFound

            if (_announcementCollectionService.Get(id) != null)
            {
                var isUpdated = await _announcementCollectionService.Update(id, announcement);
                if (isUpdated == false)
                {
                    return BadRequest("Announcement is not updated.");
                }
            }
            else
            {
                return NotFound("Announcement not found");
            }

            return Ok(announcement);
        }

        /// <summary>
        /// This is a sample DELETE method.
        /// </summary>
        /// <returns></returns>

        [HttpDelete(Name = "DeleteAnnouncement")]
        public async Task<IActionResult> DeleteAnnouncement([FromRoute] Guid id)
        {
            if (id == null)
            {
                return BadRequest("Id is null.");
            }

            //search for the announcement in the existing list
            //if found, delete the announcement
            //if not found, return NotFound

            if (_announcementCollectionService.Get(id) != null)
            {
                var isDeleted = await _announcementCollectionService.Delete(id);
                if (isDeleted == false)
                {
                    return BadRequest("Announcement is not deleted.");
                }
            }
            else
            {
                return NotFound("Announcement not found");
            }

            return Ok("Announcement deleted");
        }

        /// <summary>
        /// This is a sample PATCH method.
        /// </summary>
        /// <returns></returns>


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAnnouncement([FromBody] AnnouncementNoId announcementDto, [FromRoute] Guid id)
        {
            if (announcementDto == null)
            {
                return BadRequest("Announcement is null.");
            }

            //search for the announcement in the existing list
            //if found, update the announcement
            //if not found, return NotFound

            if (_announcementCollectionService.Get(id) != null)
            {
                var isUpdated = await _announcementCollectionService.Update(id, announcementDto);
                if (isUpdated == false)
                {
                    return BadRequest("Announcement is not updated.");
                }
            }

            else
            {
                return NotFound("Announcement not found");
            }

            return Ok(announcementDto);
        }

    }
}
