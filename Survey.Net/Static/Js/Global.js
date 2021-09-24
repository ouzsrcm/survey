function catDelete(delCatID) {
    
    var res = confirm("Are You Sure?");
    
    if (res) {

        $.ajax({
            type: 'POST',
            url: 'Ajax/Categories.asmx/deleteCategory',
            data: '{CategoryID:' + delCatID + '}',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (deleteResult) {

                if (deleteResult.d == "SUCCESS_DELETED") {

                    clearCategoryUL();
                    getCategoryList();

                }

            }
        });
    }

}
function surveyDelete(delSurveyID) {
    var res = confirm("Are You Sure?");
    if (res) {
        $.ajax({
            type: 'POST',
            url: 'Ajax/Surveys.asmx/deleteSurvey',
            data: '{SurveyID:' + delSurveyID + '}',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (deleteResult) {

                if (deleteResult.d == "SUCCESS_DELETED") {

                    clearSurveyUL();
                    getSurveyList();

                }
            }
        });
    }
}
function clearCategoryUL() {

    $("#categoryList").empty();

}
function clearSurveyUL() {

    $("#surveyList").empty();

}
function clearQuestionsUL() {

    $("#homeQuestions").empty();

}
function showEditForCategory(categoryID) {

    var editObj = $("#editInCatList" + categoryID);
    $("#modalCategoryEdit").modal();
    $("#modalCategoryEdit #modalEditCategoryFormItem").val(editObj.text());
    $("#modalCategoryEdit #modalCategoryEditCurrentCategoryID").val(categoryID);

}
function showEditForSurvey(SurveyID) {

    var surveyTitleForEdit = "";
    var surveyDescForEdit = "";
    var surveyBeginDateForEdit = "";
    var surveyEndDateForEdit = "";

    if (SurveyID != "")
    {

        /** anket bilgileri alınıyor.. */

        $.ajax({

            type: 'POST',
            url: 'Ajax/Surveys.asmx/getSingleSurvey',
            data: '{SurveyID:' + SurveyID + '}',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (SingleSurvey) {

                var jsonObjSingleSurvey = JSON.parse(SingleSurvey.d);

                $.each(jsonObjSingleSurvey,
                    function (i, item) {
                        surveyTitleForEdit = item.SurveyName;
                        surveyDescForEdit = item.Description;
                        surveyBeginDateForEdit = item.BeginDate;
                        surveyEndDateForEdit = item.EndDate;
                    }
                );

                /** alınan bilgiler yazılıyor.. */

                $("#modalSurveyEdit #modalSurveyEditedID").val(SurveyID);
                $("#modalSurveyEdit #editSurveyTitle").val(surveyTitleForEdit);
                $("#modalSurveyEdit #editSurveyDesc").val(surveyDescForEdit);
                $("#modalSurveyEdit #editSurveyBeginDate").val(surveyBeginDateForEdit);
                $("#modalSurveyEdit #editSurveyEndDate").val(surveyEndDateForEdit);
                $("#modalSurveyEdit #editSurveyBeginDate").datepicker();
                $("#modalSurveyEdit #editSurveyEndDate").datepicker();

                /** modalbox ekrana yansıtılıyor... */

                $("#modalSurveyEdit #editSurveyTitle").focus();

                $("#modalSurveyEdit").modal();

            }

        });

    }

}
function saveEditSurvey(SurveyID) {

    var editSurveyTitle = $("#modalSurveyEdit #editSurveyTitle").val();
    var editSurveyDesc = $("#modalSurveyEdit #editSurveyDesc").val();
    var editSurveyBeginDate = $("#modalSurveyEdit #editSurveyBeginDate").val();
    var editSurveyEndDate = $("#modalSurveyEdit #editSurveyEndDate").val();

    if (addSurveyTitle != "") {

        $.ajax({
            type: 'POST',
            url: 'Ajax/Surveys.asmx/saveEdit',
            data: "{Title:'" + editSurveyTitle + "', Description:'" + editSurveyDesc + "', BeginDate:'" + editSurveyBeginDate + "', EndDate:'" + editSurveyEndDate + "', SurveyID:" + SurveyID + "}",
            contentType: 'application/json; charset:utf-8',
            dataType: 'json',
            success: function (editResult) {
                if (editResult.d == "SUCCESS_EDITED") {
                    clearSurveyUL();
                    getSurveyList();
                }
            }
        });

    } else {

        $("#addSurveyTitle").focus();

    }

}
function saveChangedCategoryTitle(CategoryID, CategoryTitle) {

    if ($("#modalCategoryEdit #modalEditCategoryFormItem").val() != "") {

        $.ajax({
            type: 'POST',
            url: 'Ajax/Categories.asmx/editCategory',
            data: "{CategoryID:'" + CategoryID + "', CategoryTitle:'" + CategoryTitle + "'}",
            contentType: 'application/json; charset:utf-8',
            dataType: 'json',
            success: function (saveCatRes) {
                $("#editCategoryItemProgress").fadeOut();
                if (saveCatRes.d == "SUCCESS_EDIT") {

                    clearCategoryUL();
                    getCategoryList();

                }
            }
        });
    }

}
function getCategoryList() {

    $.ajax({
        type: 'POST',
        url: 'Ajax/Categories.asmx/getList',
        //data: '{State:1}',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (catsList) {
            var obj = JSON.parse(catsList.d);
            $.each(obj,
                function (i, item) {
                    var catDropDownMenu = '<div class="right" style="margin-right:5px;"><button onclick="catDelete(' + item.CategoryID + ')" class="btn btn-mini" type="button">X</button></div>';
                    $("#categoryList").append("<li class='catItem' data-id='" + item.CategoryID + "'><div style='width:80%' class='left edit-cursor' id='editInCatList" + item.CategoryID + "' onclick='showEditForCategory(" + item.CategoryID + ")'>" + item.Category + "</div>" + catDropDownMenu + "<div class='clear'></div></li>");
                });
        }
    });

}
function openQuestionDetails(questionID) {

    $("#contentQuestions").animate({ 'width': '56%' }, 400);
    $("#contentQuestions").addClass("left");
    $("#dvQuestionDetails").removeClass("hidden");
    $("#dvQuestionDetails").animate({ 'width': '40%' }, 400);

    var CategoryID = 0;
    var Category = "";
    var Question = "";
    var AnswerType = "";
    var AnswerTypeID = 0;

    $.ajax({
        type: 'POST',
        url: 'Ajax/Questions.asmx/getQuestionDetails',
        data: "{QuestionID:'"+ questionID +"'}",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (qDetail) {
            var obj = JSON.parse(qDetail.d);
            $.each(obj,
                function (i, item) {

                    CategoryID = item.CategoryID;
                    Category = item.Category;
                    Question = item.Question;
                    AnswerType = item.AnswerType;
                    AnswerTypeID = parseInt(item.AnswerTypeID);

                    $("#dvQdQuestionTitle").val(Question);

                    if (AnswerTypeID == 1) {
                        
                        $("#QuestDetails a[href='#freetext']").tab('show');

                        $.ajax({
                            type: 'POST',
                            url: 'Ajax/Questions.asmx/getAnswersFreeText',
                            data: '{QuestionID:' + questionID + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',
                            success: function (dataFreeText) {

                                var freeTextRes = dataFreeText.d;

                                $("#qdFreeText").val(freeTextRes);

                            }
                        });

                    } else if (AnswerTypeID == 2) {
                        
                        $("#QuestDetails a[href='#multi-select']").tab('show');

                        $.ajax({
                            type: 'POST',
                            url: 'Ajax/Questions.asmx/getAnswersMultiSelect',
                            data: '{QuestionID:' + questionID + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',
                            success: function (dataMultiSelect) {

                                var dataMultiSelect = JSON.parse(dataMultiSelect.d);

                                $("#qdMultiSelects").empty();

                                $.each(dataMultiSelect, function (i, item) {
                                    $("#qdMultiSelects").append("<li>" + item.Answer + "</li>");
                                });

                            }
                        });

                    } else if (AnswerTypeID == 3) {
                        
                        
                        $("#QuestDetails a[href='#single-select']").tab('show');

                        $.ajax({
                            type: 'POST',
                            url: 'Ajax/Questions.asmx/getAnswersSingleSelect',
                            data: '{QuestionID:' + questionID + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',
                            success: function (dataSingleSelect) {

                                var dataSingleSelect = JSON.parse(dataSingleSelect.d);

                                $("#qdSingleSelects").empty();

                                $.each(dataSingleSelect, function (i, item) {
                                    $("#qdSingleSelects").append("<li>" + item.Answer + "</li>");
                                });

                            }
                        });

                    } else if (AnswerTypeID == 4) {
                        
                        $("#QuestDetails a[href='#slider']").tab('show');

                        $.ajax({
                            type: 'POST',
                            url: 'Ajax/Questions.asmx/getAnswerSlider',
                            data: '{QuestionID:' + questionID + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: 'json',
                            success: function (dataSlider) {

                                var dataSlider = JSON.parse(dataSlider.d);

                                $("#qdSlider").empty();

                                $.each(dataSlider, function (i, item) {
                                    $("#qdSlider").append("<li>" + item.Answer + "</li>");
                                });

                            }
                        });

                    }

                });
        }

    });

}
function closeQuestionDetails() {

    $("#dvQuestionDetails").animate({ 'width': '0%' }, 400);
    $("#dvQuestionDetails").addClass("hidden");
    $("#contentQuestions").removeClass("left");
    $("#contentQuestions").animate({ 'width': '100%' }, 400);

}
function hoverQuestionItem(QuestionID) {

    

}
function addNewQuestion() {
    
    getCategoryListToAddQuestionDDL();
    getQuestionAnswerTypes();

    $("#modalAddQuestion").modal();
}
function lostHoverQuestionItem() {

    $(this).removeClass("hover-question-item");

}
function getQuestionList() {

    $.ajax({
        type: 'POST',
        url: 'Ajax/Questions.asmx/List',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (questionList) {

            var qList = JSON.parse(questionList.d);

            $.each(qList,
                function (i, item) {

                    var insTableQuestion = '<table style="width:100%;"><tr><td style="width:2%;"><input id="chkQuestID" onclick="selectThisQuestion(' + item.QuestionID + ')" type="checkbox" /></td><td style="width:96%;"><span style="cursor:text;">' + item.Question + '</span></td><td  style="width:2%;"><button type="button" class="btn" onclick="openQuestionDetails(' + item.QuestionID + ')"> > </button></td></tr></table>';

                    $("#homeQuestions").append("<li onmouseover='hoverQuestionItem(" + item.QuestionID + ")' onmouseout='lostHoverQuestionItem()'>" + insTableQuestion + "</li>");

                });

        }
    });

}
function getCategoryListToFilterDDL() {

    var Obj = null;

    $.ajax({
        type: 'POST',
        url: 'Ajax/Categories.asmx/getList',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (catsList) {
            Obj = JSON.parse(catsList.d);

            $("#filteringCategoryListDDL").append("<li><a style='cursor:pointer;' onclick='getAllQuestionsList()'>All</a></li>");

            $.each(Obj,
                function (i, item) {
                    $("#filteringCategoryListDDL").append("<li><a style='cursor:pointer;' onclick='filterQuestionsByCategory("+ item.CategoryID +")'>" + item.Category + "</a></li>");
                }
            );

        }
    });

}
function getAllQuestionsList() {
    clearQuestionsUL();
    getQuestionList();
}
function getUserInfo(currentUserID) {

    $.ajax({
        type: 'POST',
        url: 'Ajax/User.asmx/Info',
        data: "{UserID:'" + currentUserID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (userInfo) {
            if (userInfo.d != "USER_NOT_FOUND") {

                $("#userInfoDiv").html(userInfo.d);

            } else {

                location.reload();

            }
        }
    });

}
function saveCategory() {
    $("#addNewCategoryFormItems").fadeOut();
    $("#addNewCategoryItemProgress").fadeIn();
    if ($("#txtCategoryTitle").val() != "") {
        $.ajax({
            type: 'POST',
            url: 'Ajax/Categories.asmx/addCategory',
            data: "{categoryTitle:'" + $("#txtCategoryTitle").val() + "'}",
            contentType: 'application/json; charset:utf-8',
            dataType: 'json',
            success: function (saveCatRes) {
                $("#addNewCategoryItemProgress").fadeOut();
                if (saveCatRes.d == "SUCCESS_ADDED") {
                    clearCategoryUL();
                    getCategoryList();
                }
            }
        });
    } else {
        $("#txtCategoryTitle").focus();
    }
}
function getSurveyList() {

    var currObj = $("#surveyList");

    $.ajax({

        type: 'POST',
        url: 'Ajax/Surveys.asmx/List',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (List) {

            var jsonObj = JSON.parse(List.d);

            $.each(jsonObj,
                function (i, item) {

                    var btnCancelOrOK = "";

                    if (item.IsOnAir == 1) {
                        btnCancelOrOK = '<button onclick="OnAir(' + item.SurveyID + ', 0)" class="btn btn-mini" type="button" title="cancel publishing">C</button>';
                    } else {
                        btnCancelOrOK = '<button onclick="OnAir(' + item.SurveyID + ', 1)" class="btn btn-mini" type="button" title="publish now">O</button>';
                    }

                    var catDropDownMenu = '<div class="right" style="margin-right:5px;">'+ btnCancelOrOK +'<button onclick="surveyDelete(' + item.SurveyID + ')" class="btn btn-mini" type="button">X</button></div>';
                    currObj.append("<li data-id='" + item.SurveyID + "'><div style='width:80%' class='left edit-cursor' id='editInSurveyList" + item.SurveyID + "' onclick='showEditForSurvey(" + item.SurveyID + ")'>" + item.SurveyName + "</div>" + catDropDownMenu + "<div class='clear'></div></li>");
                }
            );

        }

    });

}
function OnAir(SurveyID, State) {

    var res = confirm("Are You Sure?");

    if (res) {

        $.ajax({
            type: 'POST',
            url: 'Ajax/Surveys.asmx/onAir',
            data: '{SurveyID:' + SurveyID + ', State:' + State + '}',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (deleteResult) {

                if (deleteResult.d == "SUCCESS") {

                    clearSurveyUL();
                    getSurveyList();

                }

            }
        });
    }

}
function saveAddSurvey() {

    var addSurveyTitle = $("#addSurveyTitle").val();
    var addSurveyDesc = $("#addSurveyDesc").val();
    var addSurveyBeginDate = $("#addSurveyBeginDate").val();
    var addSurveyEndDate = $("#addSurveyEndDate").val();

    if (addSurveyTitle != "") {

        $.ajax({
            type: 'POST',
            url: 'Ajax/Surveys.asmx/saveAdd',
            data: "{Title:'" + addSurveyTitle + "', Description:'" + addSurveyDesc + "', BeginDate:'" + addSurveyBeginDate + "', EndDate:'" + addSurveyEndDate + "'}",
            contentType: 'application/json; charset:utf-8',
            dataType: 'json',
            success: function (addResult) {
                if (addResult.d == "SUCCESS_ADDED") {
                    clearSurveyUL();
                    getSurveyList();
                }
            }
        });

    } else {

        $("#addSurveyTitle").focus();

    }

}
function filterQuestionsByCategory(CategoryID) {

    clearQuestionsUL();

    $("#progressForHomeQuestions").removeClass("hidden");
    $("#homeQuestions").addClass("hidden");

    $.ajax({
        type: 'POST',
        url: 'Ajax/Questions.asmx/ListByCategory',
        data: "{CategoryID:" + CategoryID + "}",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (questionListByCategory) {

            var qListByCat = JSON.parse(questionListByCategory.d);

            $.each(qListByCat,
                function (i, item) {

                    var insTableQuestion = '<table style="width:100%;"><tr><td style="width:2%;"><input id="chkQuestID" onclick="selectThisQuestion(' + item.QuestionID + ')" type="checkbox" /></td><td style="width:96%;">' + item.Question + '</td><td  style="width:2%;"><button type="button" class="btn" onclick="openQuestionDetails(' + item.QuestionID + ')"> > </button></td></tr></table>';

                    $("#homeQuestions").append("<li onmouseover='hoverQuestionItem(" + item.QuestionID + ")' onmouseout='lostHoverQuestionItem()'>" + insTableQuestion + "</li>");

                });

            $("#progressForHomeQuestions").addClass("hidden");
            $("#homeQuestions").removeClass("hidden");

        }
    });

}
function getCategoryListToAddQuestionDDL() {

    $("#modalAddQuestion #categoryIDForAddQuestion").empty();

    var Obj = null;

    $.ajax({
        type: 'POST',
        url: 'Ajax/Categories.asmx/getList',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (catsList) {
            Obj = JSON.parse(catsList.d);

            $.each(Obj,
                function (i, item) {
                    $("#modalAddQuestion #categoryIDForAddQuestion").append("<option value=" + item.CategoryID + ">" + item.Category + "</option>");
                }
            );

        }
    });

}
function getQuestionAnswerTypes() {

    $("#modalAddQuestion #answerTypeIDForAddQuestion").empty();

    $.ajax({
        type: 'POST',
        url: 'Ajax/Questions.asmx/AnswerTypesList',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (ansList) {
            ansObj = JSON.parse(ansList.d);

            $.each(ansObj,
                function (i, item) {
                    $("#modalAddQuestion #answerTypeIDForAddQuestion").append("<option value=" + item.AnswerTypeID + ">" + item.AnswerType + "</option>");
            });
        }
    });

}
function saveAddQuestion() {

    var questionNameForAddQuestion = $("#questionNameForAddQuestion");
    var categoryIDForAddQuestion = $("#categoryIDForAddQuestion");
    var answerTypeIDForAddQuestion = $("#answerTypeIDForAddQuestion");

    if (questionNameForAddQuestion.val() != "") {

        $.ajax({
            type: 'POST',
            url: 'Ajax/Questions.asmx/addNewQuestion',
            data: "{Title:'" + questionNameForAddQuestion.val() + "', CategoryID:'" + categoryIDForAddQuestion.val() + "', AnswerTypeID:'" + answerTypeIDForAddQuestion.val() + "'}",
            contentType: 'application/json; charset:utf-8',
            dataType: 'json',
            success: function (addResult) {
                if (addResult.d == "SUCCESS") {
                    clearQuestionsUL();
                    getQuestionList();
                }
            }
        });

    } else { questionNameForAddQuestion.focus(); }

}
var myScroll;
function loaded() {
    myScroll = new iScroll('contentQuestions');
}
document.addEventListener('touchmove', function (e) { e.preventDefault(); }, false);
document.addEventListener('DOMContentLoaded', loaded, false);

$(document).ready(function () {

    var catDropDownMenuNav = "";
    var currentUserID = $('.currUserID input[type="hidden"]').val();
    var currentUserCompanyID = $('.currUserCompanyID input[type="hidden"]').val();

    if (($.isNumeric(currentUserID)) && currentUserID != "") {
        /* / get user info */
        getUserInfo(currentUserID);
        // questions List
        getQuestionList();
        $("#btnCloseQuestionDetail").click(function () {
            closeQuestionDetails();
        });
        /** survey list */
        getSurveyList();
        /** category list */
        getCategoryList();
        // save changed category title
        $("#modalCategoryEditSaveButton").click(function () {
            saveChangedCategoryTitle($("#modalCategoryEditCurrentCategoryID").val(), $("#modalEditCategoryFormItem").val());
        });
        // add new question
        $("#addNewQuestion").click(function () {
            addNewQuestion();
        });
        // save new question
        $("#saveNewAddQuestion").click(function () {
            saveAddQuestion();
        });
        // cancel add category
        $("#cancelAddCategory").click(function () {
            $(".newCategoryForm").fadeOut();
        });
        // new category
        $("#newCategory").click(function () {
            $("#modalCategoryAdd").modal();
        });
        /* save cateory */
        $("#saveNewCategory").click(function () {
            saveCategory();
        });
        /** save new survey */
        $("#saveNewSurvey").click(function () {
            saveAddSurvey();
        });
        /** save edited survey */
        $("#saveEditedSurvey").click(function () {
            saveEditSurvey($("#modalSurveyEdit #modalSurveyEditedID").val());
        });
        $("#newSurvey").click(function () {
            $("#addSurveyBeginDate").datepicker();
            $("#addSurveyEndDate").datepicker();
            $("#modalSurveyAdd").modal();
        });
        /** question filtering list */
        getCategoryListToFilterDDL();

    }

    /* general */
    $(".page .page-nav").css({ 'height': $(document).height() });
    $(".page .page-container").css({ 'height': ($(document).height() - 10) });

    $("#login-process").addClass("hidden");
    $("#login-error").addClass("hidden");
    $("#login-success").addClass("hidden");
    $(".newCategoryForm").addClass("hidden");
    $("#addNewCategoryItemProgress").addClass("hidden");
    $("#modalSurveyAdd #addSurveySaveItemProgress").addClass("hidden");
    $("#addNewSurveyItemProgress").addClass("hidden");
    $("#modalCategoryEdit #editCategoryItemProgress").addClass("hidden");
    $("#modalCategoryAdd #addCategoryItemProgress").addClass("hidden");
    $("#dvQuestionDetails").addClass("hidden");
    $("#editSurveySaveItemProgress").addClass("hidden");
    $("#progressForHomeQuestions").addClass("hidden");
    $("#modalAddQuestionItemProgress").addClass("hidden");
    
});