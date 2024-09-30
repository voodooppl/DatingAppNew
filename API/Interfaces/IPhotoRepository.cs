using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IPhotoRepository
{
    public Task<IEnumerable<PhotoForApprovalDto>> GetUnapprovedPhotos();
    public Task<Photo?> GetPhotoById(int id);
    public void RemovePhoto(Photo photo);
}