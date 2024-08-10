export const formatDate = (dateString) => {
    const date = new Date(dateString);

    const dateOptions = { year: 'numeric', month: 'long', day: 'numeric' };
    
    const formattedDate = date.toLocaleDateString('en-US', dateOptions);

    return formattedDate;
};
