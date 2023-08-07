var lengthOfLongestSubstring = function (s) {
    if (s.length == 0 || s.length == 1) {
        return s.length;
    }
    let set = new Set();
    let l = 0;
    let r = 1;
};