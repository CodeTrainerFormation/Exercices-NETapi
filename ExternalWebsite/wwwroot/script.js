const url = "https://localhost:44357/classroom";

// GET : list of classroom

let myHeaders = new Headers();
myHeaders.append("Accept", "application/json; charset=utf-8");

let myInit = {
    method: "GET",
    headers: myHeaders
};

fetch(new Request(url), myInit)
    .then(response => {
        return response.json();
    })
    .then(data => {

        for (let i = 0; i < data.length; i++) {
            console.log(data[i]);
        }
    })
    .catch(err => {
        console.error(err);
    });



// GET : classroom

//let myHeaders = new Headers();
//myHeaders.append("Accept", "application/json; charset=utf-8");

//let myInit = {
//    method: "GET",
//    headers: myHeaders
//};

//fetch(new Request(`${url}/1`), myInit)
//    .then(response => {
//        return response.json();
//    })
//    .then(data => {
//       console.log(data);
//    })
//    .catch(err => {
//        console.error(err);
//    });


// POST : classroom

//class Classroom {
//    constructor(classroomid, name, floor, corridor) {
//        this.classroomid = classroomid;
//        this.name = name;
//        this.floor = floor;
//        this.corridor = corridor;
//    }
//}

//let classroom = new Classroom(0, "Salle Scott Guthrie", 2, "Orange");

////let classroom = {
////    "name": "Salle Scott Guthrie",
////    "floor": 2,
////    "corridor": "Orange"
////};

//let myHeaders = new Headers();
//myHeaders.append("Accept", "application/json; charset=utf-8");
//myHeaders.append("Content-Type", "application/json; charset=utf-8");

//let myInit = {
//    method: "POST",
//    headers: myHeaders,
//    body: JSON.stringify(classroom)
//};

//fetch(new Request(url), myInit)
//    .then(response => {
//        return response.json();
//    })
//    .then(data => {
//       console.log(data);
//    })
//    .catch(err => {
//        console.error(err);
//    });


// PUT : classroom

//class Classroom {
//    constructor(classroomid, name, floor, corridor) {
//        this.classroomid = classroomid;
//        this.name = name;
//        this.floor = floor;
//        this.corridor = corridor;
//    }
//}

//let classroom = new Classroom(8, "Salle Scott Guthrie", 2, "Orange");

////let classroom = {
////    "name": "Salle Scott Guthrie",
////    "floor": 2,
////    "corridor": "Orange"
////};

//let myHeaders = new Headers();
//myHeaders.append("Accept", "application/json; charset=utf-8");
//myHeaders.append("Content-Type", "application/json; charset=utf-8");

//let myInit = {
//    method: "PUT",
//    headers: myHeaders,
//    body: JSON.stringify(classroom)
//};

//fetch(new Request(`${url}/8`), myInit)
//    .then(response => {
//        console.log(response);
//    })
//    .catch(err => {
//        console.error(err);
//    });


// DELETE : classroom

//let myHeaders = new Headers();
//myHeaders.append("Accept", "application/json; charset=utf-8");

//let myInit = {
//    method: "DELETE",
//    headers: myHeaders
//};

//fetch(new Request(`${url}/1`), myInit)
//    .then(response => {
//        return response.json();
//    })
//    .then(data => {
//       console.log(data);
//    })
//    .catch(err => {
//        console.error(err);
//    });