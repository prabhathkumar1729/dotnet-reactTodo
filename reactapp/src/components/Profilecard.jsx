import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { changeProfile } from "../reducers/profileSlice";
import "../styles/profilepage.css";
export default function Profilecard() {
    const dispatch = useDispatch();
    const profile = useSelector((state) => state.profile.profile);
    const [isEditable, setIsEditable] = useState(false);
    const [details, setDetails] = useState(profile);
    const handleChanges = (e) => {
        e.preventDefault();
        setDetails({ ...details, [e.target.name]: e.target.value });
    };
    const handleEditClick = (e) => {
        setIsEditable(!isEditable);
    };
    const handleSaveClick = (e) => {
        e.preventDefault();
        setIsEditable(!isEditable);
        dispatch(changeProfile(details));
    };
    return (
        <>
            <div className="Profile">
                <div className="profile_container">
                    <form onSubmit={handleSaveClick}>
                        <label>
                            Name:
                            <input
                                type="text"
                                name="name"
                                defaultValue={profile.name}
                                placeholder={profile.name}
                                required
                                readOnly={!isEditable}
                                onChange={handleChanges}
                            />
                        </label>
                        <label>
                            Email:
                            <input
                                type="text"
                                name="email"
                                defaultValue={profile.email}
                                placeholder={profile.email}
                                readOnly={true}
                                onChange={handleChanges}
                            />
                        </label>
                        <label>
                            Phone Number:
                            <input
                                type="text"
                                name="phoneNo"
                                defaultValue={profile.phoneNo}
                                placeholder={profile.phoneNo}
                                required
                                readOnly={false}
                                onChange={handleChanges}
                            />
                        </label>
                        {!isEditable && <button onClick={handleEditClick}>Edit</button>}
                        {isEditable && <button type="submit">Save</button>}
                    </form>
                </div>
            </div>
        </>
    );
}
