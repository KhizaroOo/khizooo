
// LOCAL STORAGE
{

    function LS_Store(key, value) {
        if (typeof value === 'object') {
            value = JSON.stringify(value);
        }
        localStorage.setItem(key, value);
    }

    function LS_Get(key) {
        let value = localStorage.getItem(key);
        try {
            if (value === null) {
                LS_Store(key, JSON.stringify({}));
                value = JSON.stringify({});
            }
            value = JSON.parse(value);
        } catch (e) { }
        return value;
    }

    function LS_Update(key, newValue) {
        if (localStorage.getItem(key) !== null) {
            setItem(key, newValue);
        } else { }
    }

    function LS_Delete(key) {
        localStorage.removeItem(key);
    }

    function LS_Clear() {
        localStorage.clear();
    }

    function LS_GetAll() {
        const allData = {};
        for (let i = 0; i < localStorage.length; i++) {
            const key = localStorage.key(i);
            const value = localStorage.getItem(key);
            allData[key] = JSON.parse(value); // Parse JSON values
        }
        return allData;
    }

    function LS_Is_Key_Json_Exist(key) {
        try {
            const value = localStorage.getItem(key);
            if (value === null) {
                LS_Store(key, JSON.stringify({}));
                return true;
            }

            const json = JSON.parse(value);
            if (Object.keys(json).length === 0) {
                return true;
            }
        } catch (e) { return false; }
    }

    function LS_Add_New_Obj(newItem, key) {
        var storedJsonString = localStorage.getItem(key);
        var storedJsonData = storedJsonString ? JSON.parse(storedJsonString) : [];
        storedJsonData.push(newItem);
        var updatedJsonString = JSON.stringify(storedJsonData);
        localStorage.setItem(key, updatedJsonString);
    }
}
