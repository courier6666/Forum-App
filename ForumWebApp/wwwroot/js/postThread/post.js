const upvoteValue = 1;
const downvoteValue = 0;

//setting state of upvote or downvote button, whether it's pressed or not



function UpvoteClickForPost() {
    let upvoteCountLabel = document.getElementById("upvotesPostCount");
    let downvoteCountLabel = document.getElementById("downvotesPostCount");

    $.ajax({
        url: "/Votes/CheckPostVoted",
        type: 'POST',
        data: {
            postId: IdPost, voteType: upvoteValue
        },
        success:
            function (response) {
                $.ajax({
                    url: "/Votes/DeleteVote",
                    type: 'POST',
                    data: {
                        voteDeletedViewModel: { VoteType: upvoteValue, PostId: IdPost }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("upvotePostButton").classList.remove("upvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            },
        error:
            function (response) {
                $.ajax({
                    url: "/Votes/AddVote",
                    type: 'POST',
                    data: {
                        voteAddedViewModel: { VoteType: upvoteValue, PostId: IdPost }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("upvotePostButton").classList.add("upvoteButtonActive");
                            document.getElementById("downvotePostButton").classList.remove("downvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            }
    });

 
}

function DownvoteClickForPost() {
    let upvoteCountLabel = document.getElementById("upvotesPostCount");
    let downvoteCountLabel = document.getElementById("downvotesPostCount");

    $.ajax({
        url: "/Votes/CheckPostVoted",
        type: 'POST',
        data: {
            postId: IdPost, voteType: downvoteValue
        },
        success:
            function (response) {
                $.ajax({
                    url: "/Votes/DeleteVote",
                    type: 'POST',
                    data: {
                        voteDeletedViewModel: { VoteType: downvoteValue, PostId: IdPost }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("downvotePostButton").classList.remove("downvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            },
        error:
            function (response) {
                $.ajax({
                    url: "/Votes/AddVote",
                    type: 'POST',
                    data: {
                        voteAddedViewModel: { VoteType: downvoteValue, PostId: IdPost }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("downvotePostButton").classList.add("downvoteButtonActive");
                            document.getElementById("upvotePostButton").classList.remove("upvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            }
    });
}

function UpvoteClickForComment(upvoteCountLabel, downvoteCountLabel, commentId) {
    $.ajax({
        url: "/Votes/CheckCommentVoted",
        type: 'POST',
        data: {
            commentId: commentId, voteType: upvoteValue
        },
        success:
            function (response) {
                $.ajax({
                    url: "/Votes/DeleteVote",
                    type: 'POST',
                    data: {
                        voteDeletedViewModel: { VoteType: upvoteValue, CommentId: commentId }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("upvoteCommentButton" + commentId.toString()).classList.remove("upvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            },
        error:
            function (response) {
                $.ajax({
                    url: "/Votes/AddVote",
                    type: 'POST',
                    data: {
                        voteAddedViewModel: { VoteType: upvoteValue, CommentId: commentId }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("upvoteCommentButton" + commentId.toString()).classList.add("upvoteButtonActive");
                            document.getElementById("downvoteCommentButton" + commentId.toString()).classList.remove("downvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            }
    });
}

function DownvoteClickForComment(upvoteCountLabel, downvoteCountLabel, commentId) {
    $.ajax({
        url: "/Votes/CheckCommentVoted",
        type: 'POST',
        data: {
            commentId: commentId, voteType: downvoteValue
        },
        success:
            function (response) {
                $.ajax({
                    url: "/Votes/DeleteVote",
                    type: 'POST',
                    data: {
                        voteDeletedViewModel: { VoteType: downvoteValue, CommentId: commentId }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("downvoteCommentButton" + commentId.toString()).classList.remove("downvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            },
        error:
            function (response) {
                $.ajax({
                    url: "/Votes/AddVote",
                    type: 'POST',
                    data: {
                        voteAddedViewModel: { VoteType: downvoteValue, CommentId: commentId }
                    },
                    success:
                        function (response) {
                            response = JSON.parse(response);
                            upvoteCountLabel.innerText = response.countUpvotes;
                            downvoteCountLabel.innerText = response.countDownvotes;
                            document.getElementById("downvoteCommentButton" + commentId.toString()).classList.add("downvoteButtonActive");
                            document.getElementById("upvoteCommentButton" + commentId.toString()).classList.remove("upvoteButtonActive");
                        },
                    error:
                        function (response) {
                            alert(response);
                        }

                });
            }
    });
}

function SetVotePostButtonsState() {
    $.ajax({
        url: "/Votes/GetVoteTypeOfVoteOfUserForPost",
        type: 'POST',
        data: {
            postId: IdPost
        },
        success:
            function (response) {
                response = JSON.parse(response);
                if (response.voteType == upvoteValue) {
                    document.getElementById("upvotePostButton").classList.add("upvoteButtonActive");
                }
                else {
                    document.getElementById("downvotePostButton").classList.add("downvoteButtonActive");
                }
            },
        error:
            function (response) {

            }

    });
}
SetVotePostButtonsState();

function RenderCommentsForPost(comments) {
    let commentsContainer = document.getElementById("commentsContainer");

    for (let i = 0; i < comments.length; ++i) {
        let htmlComment = RenderComment(comments[i], 0, null);
        commentsContainer.append(htmlComment);
    }
}

function RenderComment(comment, offset, parentCommentHtml) {
    let commentHtml = document.createElement("div");
    commentHtml.style.paddingLeft = offset.toString() + "%";

    let commentCard = document.createElement("div");
    commentCard.className = "card";

    let commentHeader = document.createElement("div");
    commentHeader.className = "card-header";
    commentHeader.innerText = comment.Author.Username;
    commentCard.append(commentHeader);

    let commentContent = document.createElement("p");
    commentContent.className = "card-body";
    commentContent.innerText = comment.Content;
    commentCard.append(commentContent);

    commentHtml.append(commentCard);

    let repliesControlPanel = document.createElement("div");
    repliesControlPanel.style.display = "flex";
    repliesControlPanel.style.flexDirection = "row";

    let buttonSubmitReply = null;
    if (userLoggedIn) {
        let commentFormDiv = document.createElement("div");
        let commentInput = document.createElement("input");
        commentInput.type = "text";
        commentInput.placeholder = "Type your comment";
        commentInput.id = "inputReply" + comment.Id.toString();
        buttonSubmitReply = document.createElement("button");
        buttonSubmitReply.innerText = "Submit";

        commentFormDiv.style.display = "none";
        commentFormDiv.append(commentInput);
        commentFormDiv.append(buttonSubmitReply);

        let commentReply = document.createElement("a");
        commentReply.className = "commentManageButton";
        commentReply.innerText = "Reply";
        commentReply.addEventListener("click", function () {
            if (commentFormDiv.style.display == "none") {
                commentFormDiv.style.display = "block";
            }
            else {
                commentFormDiv.style.display = "none";
            }
        });

        commentHtml.append(commentReply);
        commentHtml.append(commentFormDiv);

        if (comment.Author.Id == userId) {
            let deleteButton = document.createElement("a");
            deleteButton.className = "commentManageButton";
            deleteButton.innerText = "Delete";
            deleteButton.addEventListener("click", function () { deleteComment(comment.Id, commentHtml, parentCommentHtml) });
            commentHtml.append(deleteButton);
        }
        //votes fields for comment
        let votesOfCommentDiv = document.createElement("div");
        votesOfCommentDiv.className = "voteFields";
        votesOfCommentDiv.id = "votesOfComment" + comment.Id.toString();

        //fields for upvote
        let upvotesCountLabel = document.createElement("label");
        upvotesCountLabel.innerText = comment.Votes.Upvotes.toString();
        upvotesCountLabel.className = "upvotesCount";
        upvotesCountLabel.id = "upvoteCommentCount" + comment.Id.toString();

        let upvoteButton = document.createElement("button");
        upvoteButton.className = "upvoteButton";
        upvoteButton.id = "upvoteCommentButton" + comment.Id.toString();
        upvoteButton.textContent = "Upvote";

        votesOfCommentDiv.appendChild(upvotesCountLabel);
        votesOfCommentDiv.appendChild(upvoteButton);

        //fields for downvote
        let downvotesCountLabel = document.createElement("label");
        downvotesCountLabel.innerText = comment.Votes.Downvotes.toString();
        downvotesCountLabel.className = "downvotesCount";
        downvotesCountLabel.id = "upvoteCommentCount" + comment.Id.toString();

        let downvoteButton = document.createElement("button");
        downvoteButton.className = "downvoteButton";
        downvoteButton.id = "downvoteCommentButton" + comment.Id.toString();
        downvoteButton.textContent = "Downvote";

        votesOfCommentDiv.appendChild(downvotesCountLabel);
        votesOfCommentDiv.appendChild(downvoteButton);
        //checking type of vote to change upvote and downvote button

        $.ajax({
            url: "/Votes/GetVoteTypeOfVoteOfUserForComment",
            type: 'POST',
            data: {
                commentId: comment.Id
            },
            success:
                function (response) {
                    response = JSON.parse(response);
                    if (response.voteType == upvoteValue) {
                        upvoteButton.classList.add("upvoteButtonActive");
                    }
                    else {
                        downvoteButton.classList.add("downvoteButtonActive");
                    }
                },
            error:
                function (response) {
                    
                }

        });

        //click event for upvote and downvote
        upvoteButton.addEventListener("click", function () { UpvoteClickForComment(upvotesCountLabel, downvotesCountLabel, comment.Id) });
        downvoteButton.addEventListener("click", function () { DownvoteClickForComment(upvotesCountLabel, downvotesCountLabel, comment.Id) });
        commentHtml.append(votesOfCommentDiv);
    }
 
    //replies
    let repliesHtml = null;
    commentHtml.dataset.repliesCount = 0;

    if (comment.Replies != 0) {
        let viewRepliesLink = document.createElement("a");
        viewRepliesLink.href = "#";
        viewRepliesLink.innerText = "View Replies";
        viewRepliesLink.className = "repliesViewLink";
        commentHtml.append(viewRepliesLink);

        commentHtml.dataset.repliesCount = comment.Replies;

        viewRepliesLink.addEventListener("click", function () {
            if (repliesHtml == null) {
                repliesHtml = document.createElement("div");
                repliesHtml.className = "repliesDiv";
                $.ajax({
                    url: "/Comment/GetCommentReplies",
                    type: 'POST',
                    data: {
                        commentId: comment.Id
                    },
                    success: function (response) {
                        response = JSON.parse(response);
                        for (let i = 0; i < response.length; ++i) {
                            let htmlReply = RenderComment(response[i], offset + 5, commentHtml);
                            repliesHtml.append(htmlReply);
                        }
                        repliesHtml.style.display = "block";
                        commentHtml.append(repliesHtml);
                    },

                    error: function (response) {
                        alert(response);
                    }

                });
                return;
            }
            if (repliesHtml.style.display == "none") {
                repliesHtml.style.display = "block";
            }
            else {
                repliesHtml.style.display = "none";
            }
        });
    }
    if (userLoggedIn) {
        buttonSubmitReply.onclick = function () {
            submitReplyForComment(comment.Id, commentHtml, offset + 5);
        }
    }
    return commentHtml;
}

RenderCommentsForPost(commentsData);

function submitCommentForPost() {
    let commentInput = document.querySelector("#commentForm input[type='text']");
    let comment = commentInput.value;


    $.ajax({
        url: "/Comment/AddComment",
        type: 'POST',
        data: { createdCommentViewModel: { Content: comment }, postId: IdPost },
        success:
            function (response) {
                let commentHtml = JSON.parse(response);
                globalCommentsContainer.append(RenderComment(commentHtml, 0, null));
            },
        error:
            function (response) {
                alert(response);
            }

    });

    commentInput.value = "";
}

function submitReplyForComment(commentId, commentHtml, offset) {
    let replyInput = document.getElementById("inputReply" + commentId.toString());
    let repliesDivHtml = commentHtml.querySelector(".repliesDiv");

    $.ajax({
        url: "/Comment/AddComment",
        type: 'POST',
        data: { createdCommentViewModel: { Content: replyInput.value, ParentCommentId: commentId }, postId: IdPost },
        success:
            function (response) {
                let replyObject = JSON.parse(response);
                let renderedCommentHtml = RenderComment(replyObject, offset, commentHtml);

                if (repliesDivHtml == null || repliesDivHtml == undefined) {
                    let viewRepliesLink = document.createElement("a");
                    viewRepliesLink.href = "#";
                    viewRepliesLink.innerText = "View Replies";
                    viewRepliesLink.className = "repliesViewLink";
                    commentHtml.append(viewRepliesLink);

                    viewRepliesLink.addEventListener("click", function () {
                        if (repliesDivHtml == null) {
                            repliesDivHtml = document.createElement("div");
                            repliesDivHtml.className = "repliesDiv";
                            $.ajax({
                                url: "/Comment/GetCommentReplies",
                                type: 'POST',
                                data: {
                                    commentId: comment.Id
                                },
                                success: function (response) {
                                    response = JSON.parse(response);
                                    for (let i = 0; i < response.length; ++i) {
                                        let htmlReply = RenderComment(response[i], offset + 5, commentHtml);
                                        repliesHtml.append(htmlReply);
                                    }
                                    repliesDivHtml.style.display = "block";
                                    commentHtml.append(repliesDivHtml);
                                },

                                error: function (response) {
                                    alert(response);
                                }

                            });
                            return;
                        }
                        if (repliesDivHtml.style.display == "none") {
                            repliesDivHtml.style.display = "block";
                        }
                        else {
                            repliesDivHtml.style.display = "none";
                        }
                    });
                    repliesDivHtml.style.display = "block";
                    commentHtml.append(repliesDivHtml);
                }
                else {
                    repliesDivHtml.append(renderedCommentHtml);
                }
                ++commentHtml.dataset.repliesCount;
                
            },
        error:
            function (response) {
                alert(response);
            }

    });
    replyInput.value = "";
}

function deleteComment(commentIdArg, commentHtml, parentCommentHtml) {
    $.ajax({
        url: "/Comment/DeleteComment",
        type: 'POST',
        data: { commentId: commentIdArg },
        success:
            function (response) {
                commentHtml.remove();
                --parentCommentHtml.dataset.repliesCount;
                if (parentCommentHtml.dataset.repliesCount <= 0) {
                    let repliesLink = parentCommentHtml.querySelector(".repliesViewLink");
                    repliesLink.remove();
                    let repliesDiv = parentCommentHtml.querySelector(".repliesDiv");

                    if (repliesDiv != null && repliesDiv != undefined)
                        repliesDiv.remove();
                }
            },
        error:
            function (response) {
                alert(response);
            }

    });
}

let toViewCommentInputButton = document.getElementById("commentLink");
if (toViewCommentInputButton != null) {
    toViewCommentInputButton.addEventListener("click", function () {
        var commentForm = document.getElementById("commentForm");
        if (commentForm.style.display === "none") {
            commentForm.style.display = "block";
        } else {
            commentForm.style.display = "none";
        }
    });
}
