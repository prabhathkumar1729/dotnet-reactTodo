import { createSlice, createAsyncThunk, current } from "@reduxjs/toolkit";
import profileServices from "../services/profileFetch";

export const fetchProfile = createAsyncThunk(
    'profile/setProfile',
    async (userId) => {
        const profile = await profileServices.getProfile(userId);
        return profile;
    }
);

export const changeProfile = createAsyncThunk(
    'profile/editProfile',
    async (newObject) => {
        const profile = await profileServices.editProfile(newObject);
        return profile;
    }
);



const profileSlice = createSlice({
    name: 'profile',
    initialState: {
        profile: {}
    },
    reducers: {
    },
    extraReducers(builder) {
        builder
            .addCase(fetchProfile.fulfilled, (state, action) => {
                state.profile = action.payload;
            })
            .addCase(changeProfile.fulfilled, (state, action) => {
                state.profile = action.payload;
            })
    }
});

export const { setProfile, editProfile } = profileSlice.actions;
export default profileSlice.reducer;
