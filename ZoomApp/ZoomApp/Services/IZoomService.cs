using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZoomApp.Services
{
    public interface IZoomService
    {
        bool IsInitialized();

        //Call this before other methods to Init the library
        void InitZoomLib(string appKey, string appSecret);

        void JoinMeeting(string meetingID, string meetingPassword, string displayName = "Zoom Demo");
        void LeaveMeeting(bool endMeeting = false);
        bool LoginToZoom(string email, string password, bool rememberMe = true);
        Task<object> ListMeeting();
    }
}
