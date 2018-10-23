﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLS_SLE.Models;
using System.Collections.Specialized;

namespace CLS_SLE.Controllers
{
    public class InstructorAssessmentsController : Controller
    {
        private SLE_TrackingEntities db = new SLE_TrackingEntities();

        // GET: InstructorAssessments
        public ActionResult Dashboard()
        {
            var instructorAssessments = from x in db.InstructorAssessments select x;
            Session["personID"] = 2;


            return View(instructorAssessments.ToList());
        }

        // GET: InstructorAssessments/Details/5
        public ActionResult Details(int id)
        {
            RubricDetail rubric = db.RubricDetails.FirstOrDefault(r => r.RubricID == id);

            return View(rubric);
        }

        // GET: InstructorAssessments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorAssessments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Login,PersonID,CourseID,CourseName,SectionID,CRN,AssessmentName,RubricID,RubricName,AssessmentLevel,DueDate,Status")] InstructorAssessment instructorAssessment)
        {
            if (ModelState.IsValid)
            {
                db.InstructorAssessments.Add(instructorAssessment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructorAssessment);
        }

        // GET: InstructorAssessments/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstructorAssessment instructorAssessment = db.InstructorAssessments.Find(id);
            if (instructorAssessment == null)
            {
                return HttpNotFound();
            }
            return View(instructorAssessment);
        }

        // POST: InstructorAssessments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Login,PersonID,CourseID,CourseName,SectionID,CRN,AssessmentName,RubricID,RubricName,AssessmentLevel,DueDate,Status")] InstructorAssessment instructorAssessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructorAssessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instructorAssessment);
        }

        // GET: InstructorAssessments/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstructorAssessment instructorAssessment = db.InstructorAssessments.Find(id);
            if (instructorAssessment == null)
            {
                return HttpNotFound();
            }
            return View(instructorAssessment);
        }

        // POST: InstructorAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InstructorAssessment instructorAssessment = db.InstructorAssessments.Find(id);
            db.InstructorAssessments.Remove(instructorAssessment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CLSStudentList(int rubricID)
        {
            var instructor = db.InstructorAssessments.FirstOrDefault(r => r.RubricID == rubricID);

            var students = db.SectionEnrollments.Where(c => c.sectionID == instructor.SectionID).OrderBy(c => c.LastName);

            return View(students.ToList());
        }

        public ActionResult TSAStudentList(int rubricID)
        {
            var instructor = db.InstructorAssessments.FirstOrDefault(r => r.RubricID == rubricID);

            var students = db.SectionEnrollments.Where(c => c.sectionID == instructor.SectionID).OrderBy(c => c.LastName);

            return View(students.ToList());
        }

        public ActionResult CLSAssessment(int sectionID)
        {
            var instructor = db.InstructorAssessments.FirstOrDefault(i => i.SectionID == sectionID);

            var rubric = db.InstructorAssessments.FirstOrDefault(n => n.RubricID == instructor.RubricID);
                
            var criteria = db.Outcomes.Where(c => c.RubricID == instructor.RubricID);

            var numberOfSelectors = db.ScoreTypes.Where(n => n.RubricID == instructor.RubricID);


            dynamic mymodel = new ExpandoObject();
            mymodel.Rubric = rubric;
            mymodel.Selectors = numberOfSelectors.ToList();
            mymodel.Criteria = criteria.ToList();
            

            return View(mymodel);
        }

        public ActionResult TSAAssessment(int sectionID, int enrollmentID)
        {
            var instructor = db.InstructorAssessments.FirstOrDefault(i => i.SectionID == sectionID);
            Session["instructorID"] = instructor.PersonID;
            Session["rubricID"] = instructor.RubricID;

            var student = db.SectionEnrollments.FirstOrDefault(s => s.sectionID == sectionID && s.EnrollmentID == enrollmentID);
            Session["enrollmentID"] = student.EnrollmentID;

            var rubric = db.InstructorAssessments.FirstOrDefault(n => n.RubricID == instructor.RubricID);

            var outcomes = db.Outcomes.Where(c => c.RubricID == instructor.RubricID);

            var criteria = db.RubricDetails.Where(c => c.RubricID == instructor.RubricID);
            
            var numberOfSelectors = db.ScoreTypes.Where(n => n.RubricID == instructor.RubricID);
            
            dynamic mymodel = new ExpandoObject();
            mymodel.Student = student;
            mymodel.Rubric = rubric;
            mymodel.Selectors = numberOfSelectors.ToList();
            mymodel.Outcomes = outcomes.ToList();
            mymodel.Criteria = criteria.ToList();
            
            return View(mymodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssessmentInput(FormCollection fc)
        {
            var outcomeIDs = fc.AllKeys;
            for (var t = 1; t < fc.Count; t++)
            {
                Int16 outcomeID = Convert.ToInt16(outcomeIDs[t]);
                Int16 scoreTypeID = Convert.ToInt16(fc.GetValue(outcomeID.ToString()).AttemptedValue);
                int enrollmentID = Convert.ToInt32(Session["enrollmentID"]);

                Outcome outcome = db.Outcomes.FirstOrDefault(o => o.OutcomeID == outcomeID);
                
                Criterion criteria = db.Criteria.FirstOrDefault(c => c.OutcomeID == outcome.OutcomeID && c.SortOrder == outcome.SortOrder);
                var criteriaID = criteria.CriteriaID;

                var checkIfExists = db.StudentScores.Where(c => c.EnrollmentID == enrollmentID && c.CriteriaID == criteriaID).FirstOrDefault();
                if(checkIfExists != null)
                {
                    checkIfExists.ScoreTypeID = scoreTypeID;
                }
                else
                {
                    StudentScore score = new StudentScore()
                    {
                        EnrollmentID = Convert.ToInt32(Session["enrollmentID"]),
                        CriteriaID = criteria.CriteriaID,
                        ScoreTypeID = Convert.ToSByte(scoreTypeID),
                        AssessedByID = Convert.ToInt32(Session["instructorID"]),
                        DateTimeAssessed = DateTime.Now,
                    };
                    db.StudentScores.Add(score);
                }
                db.SaveChanges();
            }

            return RedirectToAction(actionName: "TSAStudentList", controllerName: "InstructorAssessments", routeValues: new { rubricID = Session["rubricID"] });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
