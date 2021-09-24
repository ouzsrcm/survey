<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Survey.Net.Engine.Modules.Home" %>

<div class="currUserID"><asp:HiddenField ID="currUserID" runat="server" /></div>
<div class="currUserCompanyID"><asp:HiddenField ID="currUserCompanyID" runat="server" /></div>

<!-- modals -->
    <!-- categoryEdit -->
        <div id="modalCategoryEdit" data-backdrop="static" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h4 id="modalCategoryEditTitle">Edit Category </h4>
          </div>
          <div class="modal-body">
              <input id="modalCategoryEditCurrentCategoryID" type="hidden" />
              <input class="input-xlarge" id="modalEditCategoryFormItem" value="val" type="text">
              <div class="progress progress-striped active" id="editCategoryItemProgress">
                    <div class="bar" style="width:100%;">
                        Please wait...
                    </div>
                </div>
          </div>
          <div class="modal-footer">
              <button class="btn" data-dismiss="modal" id="Button1" aria-hidden="true">Close</button>
              <button class="btn btn-primary" data-dismiss="modal" id="modalCategoryEditSaveButton" aria-hidden="true">Save</button>
          </div>
        </div>
    <!-- /categoryEdit -->
    <!-- categoryAdd -->
        <div id="modalCategoryAdd" data-backdrop="static" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h4 id="H1">Add Category </h4>
          </div>
          <div class="modal-body">
              <input class="input-xlarge" id="txtCategoryTitle" value="" type="text">
              <div class="progress progress-striped active" id="addCategoryItemProgress">
                    <div class="bar" style="width:100%;">
                        Please wait...
                    </div>
                </div>
          </div>
          <div class="modal-footer">
              <button class="btn" data-dismiss="modal" id="closeCategoryAddModal" aria-hidden="true">Close</button>
              <button class="btn btn-primary" data-dismiss="modal" id="saveNewCategory" aria-hidden="true">Save</button>
          </div>
        </div>
    <!-- /categoryAdd -->
    <!-- surveyAdd -->
        <div id="modalSurveyAdd" data-backdrop="static" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h4 id="H2">Add Survey</h4>
          </div>
          <div class="modal-body">
              <label for="addSurveyTitle">Survey Title</label>
              <input class="input-xlarge" id="addSurveyTitle" value="" type="text">
              <label for="addSurveyDesc">Survey Description</label>
              <textarea name="addSurveyDesc" id="addSurveyDesc"></textarea>
              <label for="addSurveyBeginDate">Survey Begin Date</label>
              <input class="input-xlarge" id="addSurveyBeginDate" data-date-format="yyyy-mm-dd" value="" type="text">
              <label for="addSurveyEndDate">Survey End Date</label>
              <input class="input-xlarge" id="addSurveyEndDate" data-date-format="yyyy-mm-dd" value="" type="text">

              <div class="progress progress-striped active" id="addSurveySaveItemProgress">
                    <div class="bar" style="width:100%;">
                        Please wait...
                    </div>
              </div>
          </div>
          <div class="modal-footer">
              <button class="btn" data-dismiss="modal" id="closeSurveyAddModal" aria-hidden="true">Close</button>
              <button class="btn btn-primary" data-dismiss="modal" id="saveNewSurvey" aria-hidden="true">Save</button>
          </div>
        </div>
    <!-- /surveyAdd -->
    <!-- surveyEdit -->
        <div id="modalSurveyEdit" data-backdrop="static" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h4 id="H3">Edit Survey</h4>
          </div>
          <div class="modal-body">
              <input id="modalSurveyEditedID" type="hidden" value="0" />
              <label for="editSurveyTitle">Survey Title</label>
              <input class="input-xlarge" id="editSurveyTitle" value="" type="text">
              <label for="editSurveyDesc">Survey Description</label>
              <textarea name="addSurveyDesc" id="editSurveyDesc"></textarea>
              <label for="editSurveyBeginDate">Survey Begin Date</label>
              <input class="input-xlarge" id="editSurveyBeginDate" data-date-format="yyyy-mm-dd" value="" type="text">
              <label for="editSurveyEndDate">Survey End Date</label>
              <input class="input-xlarge" id="editSurveyEndDate" data-date-format="yyyy-mm-dd" value="" type="text">

              <div class="progress progress-striped active" id="editSurveySaveItemProgress">
                    <div class="bar" style="width:100%;">
                        Please wait...
                    </div>
              </div>
          </div>
          <div class="modal-footer">
              <button class="btn" data-dismiss="modal" id="closeSurveyEditModal" aria-hidden="true">Close</button>
              <button class="btn btn-primary" data-dismiss="modal" id="saveEditedSurvey" aria-hidden="true">Save</button>
          </div>
        </div>
    <!-- /surveyEdit -->
<!-- surveyEdit -->
        <div id="modalAddQuestion" data-backdrop="static" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h4 id="H4">Add Question</h4>
          </div>
          <div class="modal-body">
              
              <label for="questionNameForAddQuestion">Question Title</label>
              <input class="input-xlarge" id="questionNameForAddQuestion" value="" type="text">

              <label for="categoryIDForAddQuestion">Category</label>
              <select name="categoryIDForAddQuestion" id="categoryIDForAddQuestion">
              </select>

              <label for="answerTypeIDForAddQuestion">Question Answer Type</label>
              <select name="answerTypeIDForAddQuestion" id="answerTypeIDForAddQuestion">
              </select>

              <div class="progress progress-striped active" id="modalAddQuestionItemProgress">
                    <div class="bar" style="width:100%;">
                        Please wait...
                    </div>
              </div>
          </div>
          <div class="modal-footer">
              <button class="btn" data-dismiss="modal" id="cancelNewAddQuestion" aria-hidden="true">Close</button>
              <button class="btn btn-primary" data-dismiss="modal" id="saveNewAddQuestion" aria-hidden="true">Save</button>
          </div>
        </div>
    <!-- /surveyEdit -->
<!-- /modals -->

<div class="page">

    <div class="page-nav left">
        
        <div class="page-nav-wrapper">
            
            <div id="logo">
                survey
            </div>

            <div class="navbar">
                <div class="navbar-inner">
                    <table style="width:100%;">
                        <tr>
                            <td style="width:50%;">
                                <div class="navbar-text" id="userInfoDiv"></div>
                            </td>
                            <td>
                                <input id="LinkLogout" type="button" class="btn" value="LogOut" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class="tabs">

                <div class="bs-docs-example">
                 <ul id="myTab" class="nav nav-tabs">
                   <li class="active"><a href="#cats" data-toggle="tab">Categories</a></li>
                   <li><a href="#surveys" data-toggle="tab">Surverys</a></li>
                   <!--<li><a href="#users" data-toggle="tab">Users</a></li>-->
                 </ul>
                 <div id="leftMenuTabs" class="tab-content">
                   <div class="tab-pane fade in active" id="cats">
                       <ul class="category-list" id="categoryList"></ul>
                   </div>
                   <div class="tab-pane fade" id="surveys">
                       <ul class="surveys-list" id="surveyList"></ul>
                   </div>
                   <div class="tab-pane fade" id="users">
                       <ul class="users-list">
                            <li><a href="#">Ahmet Candata</a></li>
                            <li><a href="#">Ahmet Candata</a></li>
                            <li><a href="#">Ahmet Candata</a></li>
                            <li><a href="#">Ahmet Candata</a></li>
                       </ul>
                   </div>
                   
                 </div>

               </div>

            </div>

            <div class="nav-commands">
                <div class="bs-docs-example">
                 <ul class="nav nav-pills">
                   <li class="active">
                        <input type="button" id="newCategory" value="New Category" class="btn btn-small btn-primary" />
                   </li>
                   <li>
                       <input type="button" id="newSurvey" value="New Survey" class="btn btn-small btn-primary" />
                   </li>
                   <!--<li>
                       <input type="button" id="newUser" value="New user" class="btn btn-small btn-primary" />
                   </li>-->
                 </ul>
               </div>
            </div>

        </div>

    </div>

    <div class="page-container left">
        
        <div class="page-container-wrapper">

            <div class="navbar" style="width:99%;">

                <div class="navbar-inner">

                <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </a>
                  <a class="brand" href="#">Questions</a>
                  <div class="nav-collapse collapse navbar-responsive-collapse">
                    <ul class="nav pull-right">
                        <li><a id="addNewQuestion" style="cursor:pointer;">Add New Question</a></li>
                        <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Filter by Category <b class="caret"></b></a>
                        <ul class="dropdown-menu" id="filteringCategoryListDDL">
                        </ul>
                        </li>
                    </ul>
                    </div>
                </div>
            </div>

            <div class="well" style="width:97%;">

                <div id="contentQuestions" >
                
                    <div id="scroller">

                        <ul id="homeQuestions"></ul>

                        <div class="progress progress-striped active" id="progressForHomeQuestions">
                            <div class="bar" style="width:100%;">
                                Please wait...
                            </div>
                        </div>

                    </div>

                </div>
                
                <div id="dvQuestionDetails" class="question-details well right">
                    
                    <ul class="nav nav-pills">
                      <li><button class="btn btn-primary">Save</button></li>
                      <li><button class="btn">Cancel</button></li>
                    </ul>

                    <div class="navbar" style="width:99%;">
                      <div class="navbar-inner">
                          <button type="button" class="close right" id="btnCloseQuestionDetail" data-dismiss="modal" aria-hidden="true">×</button>
                        <a class="brand" style="width:100%;">
                            <input type="text" class="input left" style="width:99%;" value="" id="dvQdQuestionTitle" />
                        </a>
                      </div>
                    </div>
                        <ul id="QuestDetails" style="width:100%;" class="nav nav-tabs">
                            <li class="active"><a href="#freetext" data-toggle="tab">Free Text</a></li>
                            <li class=""><a href="#multi-select" data-toggle="tab" title="Multi Selection">Multi Sel.</a></li>
                            <li class=""><a href="#single-select" data-toggle="tab"  title="Single Selection">Single Sel.</a></li>
                            <li class=""><a href="#slider" data-toggle="tab">Slider</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content">
                            <div class="tab-pane fade active in" id="freetext">
                            <p>
                                <textarea id="qdFreeText" cols="20" rows="2" style="width:96%;"></textarea>
                            </p>
                            </div>
                            <div class="tab-pane fade" id="multi-select">
                            <p>
                                <ul id="qdMultiSelects"></ul>
                            </p>
                            </div>
                            <div class="tab-pane fade" id="single-select">
                            <p>
                                <ul id="qdSingleSelects"></ul>
                            </p>
                            </div>
                            <div class="tab-pane fade" id="slider">
                            <p>
                                <ul id="qdSlider"></ul>
                            </p>
                            </div>
                        </div>
                </div>

                <div class="clear"></div>

            </div>

        </div>

    </div>

    <div class="clear"></div>

</div>