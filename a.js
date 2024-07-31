async function fetchArticlesWithAuthors() {
    const url = 'https://jsonplaceholder.typicode.com/todos/1';
  
    try {
      const response = await fetch(url, {
        method: 'GET'
      });
  
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
  
      const data = await response.json();
      console.log(data);
    } catch (error) {
      console.error('There has been a problem with your fetch operation:', error);
    }
  }
  
fetchArticlesWithAuthors();
  