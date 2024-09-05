
import Box from '@mui/material/Box';
import "./home.scss"
import ImageList from '@mui/material/ImageList';
import ImageListItem from '@mui/material/ImageListItem';
import ImageListItemBar from '@mui/material/ImageListItemBar';


const Home = () => {
    const itemData = [
        {
            img: '/images/data.png',
            title: 'Database Structure'
        },
        {
            img: '/images/resume1.png',
            title: 'Company section',
            description: 'View company details ',
        },
        {
            img: '/images/10.png',
            title: 'Company section',
            description: 'create new company entries',
        },
        {
            img: '/images/4.png',
            title: 'Job Section',
            description: 'each job linked to a specific company',
        },
        {
            img: '/images/5.png',
            title: 'Job Section',
            description: 'Create and view job postings',
        },
        {
            img: '/images/6.png',
            title: 'Candidate Management',
            description: 'View candidate details',
        },
        {
            img: '/images/8.png',
            title: 'Candidate Management',
            autdescriptionor: 'Candidates can create profiles, upload their resumes',
        }, {
            img: '/images/9.png',
            title: 'Responsive Design',
            autdescriptionor: 'The navigation bar adjusts to a side menu in smaller screens.',
        },
        {
            img: '/images/11.png',
            title: 'Theme Toggling',
            autdescriptionor: 'User can switch between Dark and Light modes',
        },

    ];

    return (
        <div className='content home'>
            <h2>Welcome To Resume Management Web App</h2>


            <span>
                This is full-stack CRUD application built with React 18, ASP.NET Core 7 WebAPI, TypeScript, and Entity Framework Core, designed to manage resumes where users can upload, apply to positions, and download resumes.

            </span>
            <div className='box'>
                <Box>
                    <ul>BackEnd</ul>
                    <li>Entities</li>
                    <li>DTOs</li>
                    <li>Context</li>
                    <li>ORM</li>
                    <li>Http Methods</li>
                    <li>AutoMapper</li>
                    <li>Entities Relations</li>
                    <li>One to Many Relations</li>
                </Box >
                <Box>
                    <ul>FrontEnd </ul>
                    <li>Nested Routing</li>
                    <li>useState</li>
                    <li>useEffect</li>
                    <li>useContext</li>
                    <li>DarkMode</li>
                    <li>TypeScript Interfaces</li>
                    <li>Axios</li>
                    <li>Moment</li>
                </Box >
            </div >

            <h3>   Application Functionality     </h3>
            <ImageList sx={{ width: 500, height: 450 }}>
                {itemData.map((item) => (
                    <ImageListItem key={item.img}>
                        <img
                            srcSet={`${item.img}?w=248&fit=fill&auto=format&dpr=2 2x`}
                            src={`${item.img}?w=248&fit=fill&auto=format`}
                            alt={item.title}
                            style={{ width: '100%', height: '100%', objectFit: 'contain' }}
                            loading="lazy"
                        />
                        <ImageListItemBar
                            title={item.title}
                            subtitle={<span>{item.description}</span>}
                            position="below"
                        />
                    </ImageListItem>
                ))}
            </ImageList>




        </div >
    )
}

export default Home 
