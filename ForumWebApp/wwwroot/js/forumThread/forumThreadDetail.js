function onFollowButtonCLick(threadId) {
    $.ajax({
        url: "/ForumThread/Follow",
        type: 'POST',
        data: {
            threadId: threadId
        },
        success:
            function (response) {
                if (response) {
                    let buttonHtml = document.getElementById("handleFollowButton");
                    buttonHtml.innerText = "Unfollow";
                    buttonHtml.onclick = function () { onUnfollowButtonCLick(threadId); };
                }
            },
        error:
            function (response) {
                alert(response); 
            }

    });
}
function onUnfollowButtonCLick(threadId) {
    $.ajax({
        url: "/ForumThread/Unfollow",
        type: 'POST',
        data: {
            threadId: threadId
        },
        success:
            function (response) {
                if (response) {
                    let buttonHtml = document.getElementById("handleFollowButton");
                    buttonHtml.innerText = "Follow";
                    buttonHtml.onclick = function () { onFollowButtonCLick(threadId); };
                }
            },
        error:
            function (response) {
                alert(response); 
            }

    });
}