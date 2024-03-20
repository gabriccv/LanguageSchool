# Language Learning Center Appointment Management System

This project is developed as part of the Object-Oriented Programming course project for the academic year 2022/2023. It entails building a stand-alone GUI application using the .NET framework and WPF technology for managing individual language learning sessions in language schools.

## Project Overview

The application allows users to view language schools, schedule individual sessions, and manage user accounts. Here are the main entities within the system:

1. **Address**: Includes a unique code, street, number, city, and country.
2. **School**: Contains a unique code, name, address, and a list of languages offered.
3. **Registered User**: Holds details such as name, surname, unique ID number, gender, address, email, password, and user type (admin, teacher, student).
4. **Teacher**: Extends the registered user entity and includes the school where they are employed, the list of languages they teach, and their schedule of classes.
5. **Student**: Extends the registered user entity and includes a list of scheduled classes.
6. **Class**: Includes a unique code, the teacher for the class, date, start time, duration, status (free or reserved), and the student who booked the class.

The application supports the following functionalities:

### For Unregistered Users:

1. View all schools based on selected location and languages offered.
2. View all teachers working in a selected school.

### For Registered Users:

1. **Registration**: Unregistered users (students) can register on the system by providing personal details.
2. **Login/Logout**: Users can log in and out of the system using their unique ID number and password.
3. **Profile Management**: All registered users can view and update their personal information.
4. **Search Entities**: Users can search for registered users, teachers, and schools based on various criteria.

### For Administrators:

1. **Data Management**: Administrators have access to all entities and can add, edit, or delete data. Deletions are soft deletes, rendering data inactive.
2. **Teacher Management**: Only administrators can register teachers, including the languages they teach.
3. **Class Management**: Administrators create initial free classes for teachers and can delete any class, regardless of its status.

### For Teachers:

1. **Class Schedule**: Teachers can view their class schedule (free and reserved) for selected dates and see which student booked a class.
2. **Free Class Creation**: Teachers can create and delete their free classes. Classes cannot be created in the past, and teachers cannot delete reserved classes.

### For Students:

1. **Class Booking**: Students can view available classes for selected teachers and languages and book free classes. They can also cancel their booked classes.
2. **Scheduled Classes**: Students can view their scheduled classes.

## Database Persistence

Data persistence is achieved using a relational database.
