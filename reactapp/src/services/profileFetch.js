import React from "react";
import axios from "axios";

const baseUrl = "https://localhost:7107/api/ProfileService/";
const getProfile = async (userId) => {
    const request = await axios.get(baseUrl + `GetUser/${userId}`).then((response) => response);
  return request.data;
};

const editProfile = async (newObject) => {
  const request = await axios
      .put(baseUrl+`EditUser/${newObject.id}`, newObject)
    .then((response) => response);

  return request.data;
};

//const loginProfile = aysnc(Object) => {
//    const request = await axios.post(baseUrl + "LoginUser", Object)
//        .then((response) => response);
//    return request;
//}

export default { getProfile, editProfile };
